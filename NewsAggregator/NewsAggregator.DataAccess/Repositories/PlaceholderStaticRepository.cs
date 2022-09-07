using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class PlaceholderStaticRepository : IRepository<Placeholder>
    {
        public List<Placeholder> GetAll()
        {
            return StaticDb.items;
        }
    }
}
