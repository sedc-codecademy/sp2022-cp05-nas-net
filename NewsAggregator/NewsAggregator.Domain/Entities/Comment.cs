using NewsAggregator.Domain.Interfaces;

namespace NewsAggregator.Domain.Entities
{
    public class Comment : IEntity
    {
        public Comment() { }
        public Comment(string content, Article article, int articleId, User? user, int userId)
        {
            Content = content;
            Article = article;
            ArticleId = articleId;
            User = user;
            UserId = userId;
        }
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Article? Article { get; set; }
        public int ArticleId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}