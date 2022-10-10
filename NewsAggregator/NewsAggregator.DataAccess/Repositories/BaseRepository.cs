using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Interfaces;

namespace NewsAggregator.DataAccess.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly NewsAggregatorDbContext _dbContext;
        public BaseRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
        public T? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        public void Create(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}