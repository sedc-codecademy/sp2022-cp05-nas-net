using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment? GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Create(Comment entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
