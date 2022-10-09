
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
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public RSSFeed(string feedUrl, int categoryId)
        {
            FeedUrl = feedUrl;
            CategoryId = categoryId;
        }
    }
}
