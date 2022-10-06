using NewsAggregator.InterfaceModels.Models.Article;

namespace NewsAggregator.Services.Abstraction
{
    public interface IArticleService
    {
        ArticleDto GetArticle(int id);
        IEnumerable<ArticleDto> GetArticles();
        void CreateArticle();
        void DeleteArticle(int id);
        CommentDto AddComment(AddCommentDto dto, int id, int articleId);
        IEnumerable<CommentDto> GetUserComments(int userId);
        void DeleteComment(int id, int userId);
    }
}
