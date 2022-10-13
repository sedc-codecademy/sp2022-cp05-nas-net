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
            return _dbContext.Articles.Include(x => x.Category)
                                      .OrderByDescending(x => x.Id);
        }
        public IQueryable<Article> GetByCategory(int categoryId)
        {
            return _dbContext.Articles.Include(x => x.Category)
                                      .Where(x => x.Category.Id == categoryId)
                                      .OrderByDescending(x => x.Id);
        }
        public IQueryable<Article> GetBySearchQuery(string searchQuery)
        {
            var formatedSearchQuery = searchQuery.Replace('_', ' ');
            return _dbContext.Articles.Include(x => x.Category)
                                      .Where(x => x.Title
                                      .Contains(formatedSearchQuery) || x.Description.Contains(formatedSearchQuery))
                                      .OrderByDescending(x => x.Id);
        }
        public Article? GetById(int id)
        {
            return GetAll().Include(x => x.ArticleComments)
                           .ThenInclude(y => y.User)
                           .Include(x => x.Category)
                           .FirstOrDefault(x => x.Id == id);
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