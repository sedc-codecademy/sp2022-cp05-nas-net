using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class AdRepository : IAdRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;
        public AdRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Ad> GetAll()
        {
            return _dbContext.Ads;
        }
        public Ad? GetById(int id)
        {
            return _dbContext.Ads.SingleOrDefault(x => x.Id == id);
        }
        public void Create(Ad entity)
        {
            _dbContext.Ads.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Ad entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Ad entity)
        {
            _dbContext.Ads.Remove(entity);
            _dbContext.SaveChanges();
        }

        
    }
}
