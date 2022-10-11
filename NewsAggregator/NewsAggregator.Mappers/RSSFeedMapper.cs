<<<<<<< HEAD
﻿using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewsAggregator.Mappers
{
    public static class RSSFeedMapper
    {
        public static RSSFeedDto ToRSSFeedDto(this RSSFeed model)
        {
            return new RSSFeedDto
            {
                Id = model.Id,
                Name = model.Name,
                FeedUrl = model.FeedUrl,
                IsActive = model.IsActive,
                Category = model.Category.ToCategoryDto()
            };
        }
    }
}
=======
﻿using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewsAggregator.Mappers
{
    public static class RSSFeedMapper
    {
        public static RSSFeedDto ToRSSFeedDto(this RSSFeed model)
        {
            return new RSSFeedDto
            {
                Id = model.Id,
                Name = model.Name,
                FeedUrl = model.FeedUrl,
                IsActive = model.IsActive,
                Category = model.Category.ToCategoryDto()
            };
        }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
