namespace NewsAggregator.Domain.Entities
{
    public class Article : IEntity
    {
        private string text1;
        private string text2;
        private string id1;
        private Uri uri;
        private int id2;
        private DateTime dateTime;

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

        public Article(string text1, string text2, string id1, Uri uri, int id2, DateTime dateTime)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.id1 = id1;
            this.uri = uri;
            this.id2 = id2;
            this.dateTime = dateTime;
        }
    }
}