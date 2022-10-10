using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Abstraction
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }
}
