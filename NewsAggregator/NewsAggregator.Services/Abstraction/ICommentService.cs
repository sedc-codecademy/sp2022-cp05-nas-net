using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface ICommentService
    {
        void Create(CommentDto comment, int userId, int articleId);
        void Update(CommentDto comment, int commentId);
        void Delete(int id);
    }
}
