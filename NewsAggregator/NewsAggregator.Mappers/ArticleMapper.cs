using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Article;

namespace NewsAggregator.Mappers
{
    public static class ArticleMapper
    {
        public static ArticleDto ToArticleDto(this Article article)
        {
            return new()
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                ImageUrl = article.ImageUrl
            };
        }

        public static ArticleDetailsDto ToArticleDetailsDto(this Article article)
        {
            return new()
            {
                Id = article.Id,
                Title = article.Title,
                Description = article.Description,
                ImageUrl = article.ImageUrl,
                OriginalArticleUrl = article.OriginalArticleUrl,
                SourceUrl = article.SourceUrl,
                SourceLogo = article.SourceLogo,
                DatePublished = article.DatePublished
            };
        }
    }
}