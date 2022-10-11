<<<<<<< HEAD
﻿
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Domain.Entities
{
    public class RSSFeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public RSSFeed(string name, string feedUrl, int categoryId)
        {
            Name = name;
            FeedUrl = feedUrl;
            CategoryId = categoryId;
        }
        public void Update(UpdateRSSDto model)
        {
            Name = model.Name;
            FeedUrl = model.FeedUrl;
            CategoryId = model.CategoryId;
        }
        public void ToggleIsActive()
        {
            IsActive = !IsActive;
        }
    }
}
=======
﻿
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Domain.Entities
{
    public class RSSFeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public RSSFeed(string name, string feedUrl, int categoryId)
        {
            Name = name;
            FeedUrl = feedUrl;
            CategoryId = categoryId;
        }
        public void Update(UpdateRSSDto model)
        {
            Name = model.Name;
            FeedUrl = model.FeedUrl;
            CategoryId = model.CategoryId;
        }
        public void ToggleIsActive()
        {
            IsActive = !IsActive;
        }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
