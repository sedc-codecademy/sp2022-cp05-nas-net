using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;

        public CategoryRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Category> GetAll()
        {
            return _dbContext.Categories;
        }

        public Category? GetById(int id)
        {
            return _dbContext.Categories.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Category entity)
        {
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Category entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Category entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
