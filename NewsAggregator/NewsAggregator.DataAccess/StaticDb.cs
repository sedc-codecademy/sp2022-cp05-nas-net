using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess
{
    public class StaticDb
    {
        public static List<Placeholder> items = new List<Placeholder>
        {
            new Placeholder{Id = 1 , Name="Entity 1"},
            new Placeholder{Id = 2 , Name="Entity 2"},
            new Placeholder{Id = 3 , Name="Entity 3"}
        };
    }
}
