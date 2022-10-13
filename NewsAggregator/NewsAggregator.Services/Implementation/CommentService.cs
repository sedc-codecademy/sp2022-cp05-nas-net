using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.InterfaceModels.Models.Comment;
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
        public void Create(CommentDto comment, int userId, int articleId)
        {
            var user = _userRepository.GetById(userId) ?? throw new UserException(404, "User not found");

            var article = _articleRepository.GetById(articleId) ?? throw new Exception("Article not found");

            if (string.IsNullOrEmpty(comment.Content))
            {
                throw new Exception("Text field is required!");
            }
            var newComment = user.AddComment(comment.Content, article);
            _commentRepository.Create(newComment);
        }
        public void Update(CommentDto comment, int commentId)
        {
            var entity = _commentRepository.GetById(commentId) ?? throw new Exception("Comment not found!");
            entity.Update(comment);
            _commentRepository.Update(entity);
        }
        public void Delete(int id)
        {
            var comment = _commentRepository.GetById(id) ?? throw new Exception("Comment not found!");

            _commentRepository.Delete(comment);
        }
    }
}
