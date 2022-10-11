<<<<<<< HEAD
﻿using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Abstraction
{
    public interface IRSSFeedRepository :IRepository<RSSFeed>
    {
        IQueryable<RSSFeed> GetActiveFeeds();
    }
}
=======
﻿using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Abstraction
{
    public interface IRSSFeedRepository :IRepository<RSSFeed>
    {
        IQueryable<RSSFeed> GetActiveFeeds();
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
