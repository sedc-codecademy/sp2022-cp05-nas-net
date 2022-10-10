using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Comment;

namespace NewsAggregator.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new()
            {
                Id = comment.Id,
                Content = comment.Content,
                DateCreated = comment.DateCreated,
                ArticleId = comment.ArticleId,
                UserId = comment.UserId
            };
        }
    }
}
