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
        CommentDto GetById(int commentId);
        int Create(CreateCommentDto comment, int userId);
        void Update(UpdateCommentDto comment, int commentId, int userId);
        void Delete(int id);
    }
}
