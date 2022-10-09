
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
        public string FeedUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
