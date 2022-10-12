using NewsAggregator.Domain.Interfaces;

namespace NewsAggregator.Domain.Entities
{
    public class Article : IEntity
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string OriginalArticleUrl { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty;
        public string SourceLogo { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime DatePublished { get; set; }
        public ICollection<Comment> ArticleComments { get; set; }
        public Article() { }
        public Article(string title, string description, string imageUrl, string originalArticleUrl, string sourceUrl, string sourceLogo, int categoryId, DateTime datePublished)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            OriginalArticleUrl = originalArticleUrl;
            SourceUrl = sourceUrl;
            SourceLogo = sourceLogo;
            CategoryId = categoryId;
            DatePublished = datePublished;
        }
    }
}