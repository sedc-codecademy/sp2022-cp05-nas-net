<<<<<<< HEAD
﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.InterfaceModels.Models.Category;

namespace NewsAggregator.InterfaceModels.Models.RSSFeed
{
    public class RSSFeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public CategoryDto Category { get; set; }
    }
}
=======
﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.InterfaceModels.Models.Category;

namespace NewsAggregator.InterfaceModels.Models.RSSFeed
{
    public class RSSFeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public CategoryDto Category { get; set; }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
