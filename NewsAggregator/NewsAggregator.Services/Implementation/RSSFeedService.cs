using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.InterfaceModels.Models.RSSFeed;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Implementation
{
    public class RSSFeedService : IRSSFeedService
    {
        private readonly IRSSFeedRepository _rssRepository;

        public RSSFeedService(IRSSFeedRepository rssRepository)
        {
            _rssRepository = rssRepository;
        }
        public List<RSSFeedDto> GetAll()
        {
            return _rssRepository.GetAll().Select(x => x.ToRSSFeedDto()).ToList();
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
