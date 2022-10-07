namespace NewsAggregator.InterfaceModels.Models.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
    }
}