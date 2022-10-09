using NewsAggregator.InterfaceModels.Models.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface IRSSFeedService
    {
        List<RSSFeedDto> GetAll();
        void Create();
        void Update();
        void Delete();
    }
}
