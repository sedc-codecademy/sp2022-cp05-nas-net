using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Domain.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public Article? Article { get; set; }
        public int ArticleId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Comment() { }
        public Comment(string content, int articleId, int userId)
        {
            Content = content;
            DateCreated = DateTime.Now;
            ArticleId = articleId;
            UserId = userId;
        }
        public void Update(CommentDto model)
        {
            Content = model.Content;
            DateCreated = model.DateCreated;
            ArticleId = model.ArticleId;
            UserId = model.UserId;
        }
    }
}