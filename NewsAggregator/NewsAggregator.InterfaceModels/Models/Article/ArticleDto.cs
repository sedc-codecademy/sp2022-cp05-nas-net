using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.InterfaceModels.Models.Article
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string OriginalArticleUrl { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty; 
        public string SourceLogo { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public IEnumerable<CommentDto> CommentsDto { get; set; } = new List<CommentDto>();
    }
}