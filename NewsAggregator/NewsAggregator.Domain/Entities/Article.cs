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
        public string Content { get; set; } = string.Empty;
        public IList<Comment> ArticleComments { get; set; } = new List<Comment>();
        public IList<Category> Categories { get; set; } = new List<Category>();
        public DateTime DatePublished { get; set; }
        public Article() { }
        public Article(string title, string description, string imageUrl, string originalArticleUrl, string sourceUrl, string sourceLogo, string content, DateTime datePublished)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            OriginalArticleUrl = originalArticleUrl;
            SourceUrl = sourceUrl;
            SourceLogo = sourceLogo;
            Content = content;
            DatePublished = datePublished;
        }
    }
}