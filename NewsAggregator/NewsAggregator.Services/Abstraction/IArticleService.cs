using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Services.Abstraction
{
    public interface IArticleService
    {
        List<ArticleDto> GetArticles();
        ArticleDto GetArticle(int id);
        void DeleteArticle(int id);
    }
}
