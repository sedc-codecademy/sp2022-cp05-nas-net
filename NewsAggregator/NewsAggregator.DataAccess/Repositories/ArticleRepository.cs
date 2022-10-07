using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;

        public ArticleRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article? GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Create(Article entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }
    
    }
}
