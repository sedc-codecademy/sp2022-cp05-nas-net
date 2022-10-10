using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Domain.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Article? Article { get; set; }
        public int ArticleId { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }
        public Comment() { }
        public Comment(string content, DateTime datecreated, int articleId, int userId)
        {
            Content = content;
            DateCreated = datecreated;
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