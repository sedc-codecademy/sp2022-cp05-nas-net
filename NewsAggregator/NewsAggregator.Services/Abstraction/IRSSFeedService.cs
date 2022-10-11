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
        RSSFeedDto GetById(int id);
        int Create(CreateRSSFeedDto model);
        void Update(UpdateRSSDto model , int id);
        bool Toggle(int id);
        void Delete(int id);
    }
}
