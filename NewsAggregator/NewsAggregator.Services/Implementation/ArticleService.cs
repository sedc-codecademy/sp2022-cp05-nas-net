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
                                            .Where(x => x.Id == id)
                                            .FirstOrDefault()
                                            ?? throw new Exception("Article not found"); //TODO change to custom exception

            var dto = article.ToArticleDto();

           /* dto.CommentsDto = GetArticleComments(id);*/ //--> INCLUDE FROM ARTICLE REPOSITORY

            return dto;
        }
        public List<ArticleDto> GetArticles()
        {
            var articles = _articleRepository.GetAll()
                                             .Include(x => x.ArticleComments);

            var articlesDto = articles.Select(x => x.ToArticleDto()).ToList();
            /*articlesDto.ForEach(x => x.CommentsDto = GetArticleComments(x.Id));*/  //--> INCLUDE FROM ARTICLE REPOSITORY

            return articlesDto;
        }
      
      
        public void DeleteArticle(int id)
        {
            var article = _articleRepository.GetById(id) ?? throw new Exception("Article not found"); //TODO change to custom exception

            _articleRepository.Delete(article);
        }
    }
}