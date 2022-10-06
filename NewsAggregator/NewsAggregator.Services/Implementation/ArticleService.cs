using Microsoft.EntityFrameworkCore;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.DataAccess.Repositories;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Article;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Services.Implementation
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentsRepository;

        public ArticleService(IRepository<Article> repository, IRepository<Comment> commentsRepository, IRepository<User> userRepository)
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

            dto.CommentsDto = GetArticleComments(id);

            return dto; 
        }
        public IEnumerable<ArticleDto> GetArticles()
        {
            var articles = _articleRepository.GetAll()
                                             .Include(x => x.ArticleComments);

            var articlesDto = articles.Select(x => x.ToArticleDto()).ToList();
            articlesDto.ForEach(x => x.CommentsDto = GetArticleComments(x.Id));

            return articlesDto;
        }
        public CommentDto AddComment(AddCommentDto dto, int userId, int articleId)
        {
            var user = _userRepository.GetById(userId) ?? throw new UserException(404, "User not found");
            var article = _articleRepository.GetById(articleId) ?? throw new Exception("Article not found");

            var comment = user.AddComment(dto.Comment, article);
            _commentsRepository.Create(comment);

            return comment.ToCommentDto(); ;
        }
        //public CommentDto EditComment(AddCommentDto dto, string username, int commentId)
        //{
        //    var user = _userRepository.GetAll().Where(x => x.Username == username).FirstOrDefault() ?? throw new UserException(404, "User not found");
        //    var comment = _commentsRepository.GetById(commentId) ?? throw new Exception();

        //    comment.Content = dto.Comment;

        //    _commentsRepository.Update(comment);

        //    return comment.ToCommentDto();
        //} // TBD with the team, will comments be allowed to be edited
        private IEnumerable<CommentDto> GetArticleComments(int articleId)
        {
            var comments = _commentsRepository.GetAll().Where(x => x.ArticleId == articleId).Include(x => x.User);

            return comments.Select(x => x.ToCommentDto()).ToList();
        }
        public IEnumerable<CommentDto> GetUserComments(int userId)
        {
            var comments = _commentsRepository.GetAll().Where(x => x.UserId == userId).Include(x => x.User);

            return comments.Select(x => x.ToCommentDto()).ToList();
        }
        //public IEnumerable<CommentDto> GetAllComments()
        //{
        //    return _commentsRepository.GetAll().Select(x => x.ToCommentDto()).ToList();
        //} // ДАЛИ Е ВООПШТО ПОТРЕБНО ОВА?
        public void DeleteComment(int id, int userId)
        {
            var comment = _commentsRepository.GetById(id) ?? throw new Exception();
            var user = _userRepository.GetById(userId) ?? throw new UserException(404, "User not found");
            if (comment.UserId != user.Id && !user.IsAdmin)
            {
                throw new Exception("You don't have permissions to delete this comment"); //TODO custom Forbidden exception
            }

            _commentsRepository.Delete(comment);
        }       
        public void CreateArticle()
        {
            //var articles = logic for getting and converting rss feed and logic for preventing duplicates creation
            //if(articles.Any())
            //{
            ////foreach(var article in articles)
            //{
            //  _articleRepository.Create(article);
            //}
            //}
        }
        public void DeleteArticle(int id)
        {
            var article = _articleRepository.GetById(id) ?? throw new Exception("Article not found"); //TODO change to custom exception

            _articleRepository.Delete(article);
        }
    }
}