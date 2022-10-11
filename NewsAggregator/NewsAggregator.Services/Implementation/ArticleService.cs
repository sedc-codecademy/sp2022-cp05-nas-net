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
        public ArticleDetailsDto GetArticle(int id)
        {
            var article = _articleRepository.GetById(id);

            if (article == null)
            {
                throw new ArticleException(404, id, $"Article with ID:{id} does not exist");
            }

            return article.ToArticleDetailsDto();
        }
        public ArticlesPaginationDto GetArticles(int pageNum)
        {
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int itemsPerPage = 10;

            var articles = _articleRepository.GetAll();

            var pagination = articles.Skip((pageNum - 1) * itemsPerPage)
                                     .Take(itemsPerPage)
                                     .Select(x => x.ToArticleDto())
                                     .ToList();

            var articlesPagination = new ArticlesPaginationDto(itemsPerPage, pageNum, articles.Count(), pagination);

            return articlesPagination;
        }

        public ArticlesPaginationDto GetArticlesByCategory(int categoryId, int pageNum)
        {
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int itemsPerPage = 10;

            var articles = _articleRepository.GetByCategory(categoryId);

            var pagination = articles.Skip((pageNum - 1) * itemsPerPage)
                                     .Take(itemsPerPage)
                                     .Select(x => x.ToArticleDto())
                                     .ToList();
            var articlesPagination = new ArticlesPaginationDto(itemsPerPage, pageNum, articles.Count(), pagination);
            return articlesPagination;
        }
        public ArticlesPaginationDto GetArticlesBySearchValue(string searchValue, int pageNum)
        {
            //Numbers of articles shown is based on the initial FE implementation, but can be changed depending on the current FE if needed.
            const int itemsPerPage = 10;

            var articles = _articleRepository.GetBySearchQuery(searchValue);

            var pagination = articles.Skip((pageNum - 1) * itemsPerPage)
                                     .Take(itemsPerPage)
                                     .Select(x => x.ToArticleDto())
                                     .ToList();
            var articlesPagination = new ArticlesPaginationDto(itemsPerPage, pageNum, articles.Count(), pagination);
            return articlesPagination;
        }

        public void DeleteArticle(int id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
            {
                throw new ArticleException(404, id, $"Article with ID :{id} does not exist.");
            }

            _articleRepository.Delete(article);
        }
    }
}