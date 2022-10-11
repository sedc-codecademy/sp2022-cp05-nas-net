using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Abstraction
{
    public interface IArticleRepository : IRepository<Article>
    {
        public IQueryable<Article> GetByCategory(int categoryId);
        public IQueryable<Article> GetBySearchQuery(string searchQuery);
        Task CreateMany(List<Article> entities);
    }
}
