using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.RSSFeed
{
    public class CreateRSSFeedDto
    {
        public string Name { get; set; }
        public string FeedUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
