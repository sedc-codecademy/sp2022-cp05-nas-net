using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Implementation
{
    public class RSSFeedService : IRSSFeedService
    {
        private readonly IRSSFeedRepository _rssRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RSSFeedService(IRSSFeedRepository rssRepository, ICategoryRepository categoryRepository)
        {
            _rssRepository = rssRepository;
            _categoryRepository = categoryRepository;
        }
        public List<RSSFeedDto> GetAll()
        {
            return _rssRepository.GetAll().Select(x => x.ToRSSFeedDto()).ToList();
        }
        public RSSFeedDto GetById(int id)
        {
            var item = _rssRepository.GetById(id);
            if (item == null)
            {
                throw new RSSFeedException(404, id, $"RSS feed with ID : {id} does not exist");
            }
            return item.ToRSSFeedDto();
        }
        public int Create(CreateRSSFeedDto model)
        {
            ValidateModel(model.Name, model.FeedUrl, model.CategoryId);
            var newRssFeed = new RSSFeed(model.Name, model.FeedUrl, model.CategoryId);
            _rssRepository.Create(newRssFeed);
            return newRssFeed.Id;
        }
        public void Update(UpdateRSSDto model, int id)
        {
            var rssFeed = _rssRepository.GetById(id);
            if (rssFeed == null)
            {
                throw new RSSFeedException(404, id, $"RSS feed with ID : {id} does not exist");
            }
            ValidateModel(model.Name, model.FeedUrl, model.CategoryId, id);
            rssFeed.Update(model);
            _rssRepository.Update(rssFeed);
        }
        public bool Toggle(int id)
        {
            var rssFeed = _rssRepository.GetById(id);
            if (rssFeed == null)
            {
                throw new RSSFeedException(404, id, $"RSS feed with ID : {id} does not exist");
            }
            rssFeed.ToggleIsActive();
            _rssRepository.Update(rssFeed);
            return rssFeed.IsActive;
        }

        public void Delete(int id)
        {
            var rssFeed = _rssRepository.GetById(id);
            if (rssFeed == null)
            {
                throw new RSSFeedException(404, id, $"RSS feed with ID : {id} does not exist");
            }
            _rssRepository.Delete(rssFeed);
        }

        private void ValidateModel(string name, string feedUrl, int categoryId, int rssId = 0)
        {
            var feeds = _rssRepository.GetAll();
            if (string.IsNullOrEmpty(name))
            {
                throw new RSSFeedException(401, "Rss feed name cannot be empty.");
            }
            if (feeds.Any(x => x.Name == name && x.Id != rssId))
            {
                throw new RSSFeedException(401, $"Rss feed with the name : \"{name}\" already exists.");
            }
            if (string.IsNullOrEmpty(feedUrl))
            {
                throw new RSSFeedException(401, "Rss feed url cannot be empty.");
            }

            if (!Uri.IsWellFormedUriString(feedUrl, UriKind.Absolute))
            {
                throw new RSSFeedException(401, "Invaid Rss feed url format.");
            }
            if (feeds.Any(x => x.FeedUrl == feedUrl && x.Id != rssId))
            {
                throw new RSSFeedException(401, $"Rss feed with the url : \"{feedUrl}\" already exists.");
            }
            if (_categoryRepository.GetById(categoryId) == null)
            {
                throw new CategoryException(404, categoryId, $"Category with ID:{categoryId} does not exist");
            }
        }

        
    }
}