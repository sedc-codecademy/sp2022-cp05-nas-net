using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;
        public CommentRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Comment> GetAll()
        {
            return _dbContext.Comments;
        }
        public Comment? GetById(int id)
        {
            return _dbContext.Comments.SingleOrDefault(c => c.Id == id);
        }
        public void Create(Comment entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Comment entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(Comment entity)
        {
            _dbContext.Comments.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
