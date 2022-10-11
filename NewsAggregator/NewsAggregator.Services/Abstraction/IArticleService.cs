using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Services.Abstraction
{
    public interface IArticleService
    {
        ArticlesPaginationDto GetArticles(int pageNum);
        ArticlesPaginationDto GetArticlesByCategory(int categoryId, int pageNum);
        ArticlesPaginationDto GetArticlesBySearchValue(string searchValue, int pageNum);
        ArticleDetailsDto GetArticle(int id);
        void DeleteArticle(int id);
    }
}
