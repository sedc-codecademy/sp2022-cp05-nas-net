using NewsAggregator.InterfaceModels.Models.Category;
using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.InterfaceModels.Models.Article
{
    public class ArticleDetailsDto : ArticleDto
    {
        public string OriginalArticleUrl { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty;
        public string SourceLogo { get; set; } = string.Empty;
        public DateTime DatePublished { get; set; }
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
        public CategoryDto? Category { get; set; }
    }
}