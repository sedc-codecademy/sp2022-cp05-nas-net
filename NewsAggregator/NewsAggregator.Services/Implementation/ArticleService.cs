using Microsoft.EntityFrameworkCore;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.DataAccess.Repositories;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.InterfaceModels.Models.Comment;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentsRepository;

        public ArticleService(IArticleRepository repository, ICommentRepository commentsRepository, IUserRepository userRepository)
        {
            _articleRepository = repository;
            _commentsRepository = commentsRepository;
            _userRepository = userRepository;
        }
        public ArticleDto GetArticle(int id)
        {
            var article = _articleRepository.GetAll()
                                            .Include(x => x.ArticleComments)
                                            .Include(x => x.Category)
                                            .Where(x => x.Id == id)
                                            .FirstOrDefault()
                                            ?? throw new Exception("Article not found"); //TODO change to custom exception

            var dto = article.ToArticleDto();

            dto.Category = article.Category.ToCategoryDto();
           /* dto.CommentsDto = GetArticleComments(id);*/ //--> INCLUDE FROM ARTICLE REPOSITORY
            
            return dto;
        }
        public List<ArticleDto> GetArticlesHomepage(int pageNum)
        {
            //CommentsDto won't be needed since it's only for accessing a particular article.
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int articlesShown = 5;

            var articles = _articleRepository.GetAll()
                                             .OrderByDescending(x => x.Id)
                                             .Skip(pageNum * articlesShown)
                                             .Take(articlesShown);

            var articlesDto = articles.Select(x => x.ToArticleDto());

            return articlesDto.ToList();
        }

        public List<ArticleDto> GetArticlesByCategory(string categoryName, int pageNum)
        {
            //CommentsDto won't be needed since it's only for accessing a particular article.
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int articlesShown = 10;

            var articles = _articleRepository.GetAll()
                                             .Include(x => x.Category)
                                             .Where(x => x.Category.Name == categoryName)
                                             .OrderByDescending(x => x.Id)
                                             .Skip(pageNum * articlesShown)
                                             .Take(articlesShown);

            var articlesDto = articles.Select(x => x.ToArticleDto());

            return articlesDto.ToList();
        }
        public List<ArticleDto> GetArticlesBySearchValue(string searchValue, int pageNum)
        {
            //CommentsDto won't be needed since it's only for accessing a particular article.
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int articlesShown = 10;

            var articles = _articleRepository.GetAll()
                                             .Include(x => x.Category)
                                             .Where(x => x.Title.Contains(searchValue) || x.Description.Contains(searchValue))
                                             .OrderByDescending(x => x.Id)
                                             .Skip(pageNum * articlesShown)
                                             .Take(articlesShown);

            var articlesDto = articles.Select(x => x.ToArticleDto());

            return articlesDto.ToList();
        }

        public void DeleteArticle(int id)
        {
            var article = _articleRepository.GetById(id) ?? throw new Exception("Article not found"); //TODO change to custom exception

            _articleRepository.Delete(article);
        }
    }
}