using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Comment;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IArticleRepository _articleRepository;

        public CommentService(ICommentRepository commentRepository, IUserRepository userRepository, IArticleRepository articleRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _articleRepository = articleRepository;
        }
        public CommentDto GetById(int commentId)
        {
            var res = _commentRepository.GetById(commentId);
            if (res == null)
            {
                throw new CommentException(404, commentId, $"Comment with ID : {commentId} does not exist");
            }
            return res.ToCommentDto();
        }
        public int Create(CreateCommentDto comment, int userId)
        {

            var article = _articleRepository.GetById(comment.ArticleId);
            if (article == null)
            {
                throw new ArticleException(404, comment.ArticleId, $"Article with ID:{comment.ArticleId} does not exist.");
            }
            if (string.IsNullOrEmpty(comment.Content))
            {
                throw new CommentException(400, "Content field cannot be empty.");
            }
            var newComment = new Comment(comment.Content, comment.ArticleId, userId);
            _commentRepository.Create(newComment);
            return newComment.Id;
        }
        public void Update(UpdateCommentDto comment, int commentId, int userId)
        {
            var entity = _commentRepository.GetById(commentId);
            if (entity == null)
            {
                throw new CommentException(404, commentId, $"Comment with ID : {commentId} does not exist");
            }
            if (entity.User.Id != userId)
            {
                throw new UserException(401, "You are not authorized to perform this action.");
            }
            if (string.IsNullOrEmpty(comment.Content))
            {
                throw new CommentException(400, "Content field cannot be empty.");
            }
            entity.Update(comment);
            _commentRepository.Update(entity);
        }
        public void Delete(int id)
        {
            var comment = _commentRepository.GetById(id) ?? throw new CommentException(404 , id , $"Comment with ID:{id} does not exist.");
            _commentRepository.Delete(comment);
        }
    }
}
