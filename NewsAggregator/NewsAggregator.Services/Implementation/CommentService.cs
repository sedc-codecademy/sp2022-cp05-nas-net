using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Comment;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;

namespace NewsAggregator.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(Comment comment)
        {
            if (string.IsNullOrEmpty(comment.Content))
            {
                throw new Exception("Text field is required!");
            }
            _commentRepository.Create(comment);
        }
        public void Update(Comment comment, int commentId)
        {
            var entity = _commentRepository.GetById(commentId) ?? throw new Exception("Comment not found!");

            _commentRepository.Update(entity);
        }
        public void Delete(int id)
        {
            var comment = _commentRepository.GetById(id) ?? throw new Exception("Comment not found!");

            _commentRepository.Delete(comment);
        }
    }
}
