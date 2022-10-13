using NewsAggregator.InterfaceModels.Models.User;

namespace NewsAggregator.InterfaceModels.Models.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public int ArticleId { get; set; }
        public CommentOwnerDto User { get; set; }
    }
}