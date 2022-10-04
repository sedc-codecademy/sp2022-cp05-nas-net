using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly NewsAggregatorDbContext _dbContext;

        public UserRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }
        public User GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }
        public void Create(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(User entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
