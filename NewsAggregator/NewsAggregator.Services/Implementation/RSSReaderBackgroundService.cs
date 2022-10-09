using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NewsAggregator.Services.Implementation
{
    public class RSSReaderBackgroundService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromHours(5));

        private readonly IServiceProvider _serviceProvider;

        public RSSReaderBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await GetRssFeedData();

            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await GetRssFeedData();
            }
        }

        private async Task GetRssFeedData()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var rssRepository = scope.ServiceProvider.GetRequiredService<IRSSFeedRepository>();
                    var articleRepository = scope.ServiceProvider.GetRequiredService<IArticleRepository>();
                    var newArticles = new List<Article>();
                    var rssFeeds = rssRepository.GetAll();
                    foreach (var rssFeed in rssFeeds)
                    {
                        var settings = new XmlReaderSettings();
                        using var reader = XmlReader.Create(rssFeed.FeedUrl, settings);
                        var feed = SyndicationFeed.Load(reader);
                        var items = feed.Items;
                        var images = GetArticleImageUrls(rssFeed.FeedUrl);

                        foreach (var item in items.Select((value, i) => new { i, value }))
                        {
                            var value = item.value;
                            var index = item.i;
                            var newArticle = new Article
                            {
                                Title = value.Title.Text,
                                Description = value.Summary.Text,
                                ImageUrl = images[index],
                                OriginalArticleUrl = value.Id,
                                SourceUrl = feed.Links.First().Uri.ToString(),
                                SourceLogo = feed.ImageUrl.ToString(),
                                CategoryId = (int)rssFeed.CategoryId,
                                DatePublished = new DateTime(value.PublishDate.Year, value.PublishDate.Month, value.PublishDate.Day)
                            };
                            newArticles.Add(newArticle);
                        }
                    }
                    await articleRepository.CreateMany(newArticles);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        private List<string> GetArticleImageUrls(string feedUrl)
        {
            XDocument xDoc = XDocument.Load(feedUrl);
            XNamespace media = XNamespace.Get("http://search.yahoo.com/mrss/");
            var images = new List<string>();
            var items = xDoc.Descendants("item");
            foreach (var item in items)
            {
                var imageUrls = item.Descendants(media + "content");
                if (imageUrls.Count() > 0)
                {
                    var imageUrl = imageUrls.First().Attribute("url").Value;
                    images.Add(imageUrl);
                }
                else
                {
                    images.Add("https://cdn.pixabay.com/photo/2013/07/12/19/16/newspaper-154444__340.png");
                }
            }
            return images;
        }
    }
}