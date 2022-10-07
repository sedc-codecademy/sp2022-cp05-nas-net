using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Username = comment.User.Username
            };
        }
    }
}
