using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Articles;
        }
        public Article? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        public void Create(Article entity)
        {
            throw new NotImplementedException();
        }
        public async Task CreateMany(List<Article> entities)
        {
            foreach (var entity in entities)
            {
                if (_dbContext.Articles.All(x => x.OriginalArticleUrl != entity.OriginalArticleUrl) || _dbContext.Articles.Count() == 0)
                {
                    _dbContext.Articles.Add(entity);
                }
            }
            await _dbContext.SaveChangesAsync();
        }
        public void Update(Article entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Article entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}