using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Services.Abstraction
{
    public interface IArticleService
    {
        List<ArticleDto> GetArticlesHomepage(int pageNum);
        List<ArticleDto> GetArticlesByCategory(string categoryName, int pageNum);
        List<ArticleDto> GetArticlesBySearchValue(string searchValue, int pageNum);
        ArticleDto GetArticle(int id);
        void DeleteArticle(int id);
    }
}
