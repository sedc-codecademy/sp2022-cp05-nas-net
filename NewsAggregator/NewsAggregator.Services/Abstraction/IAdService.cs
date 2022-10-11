using NewsAggregator.InterfaceModels.Models.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface IAdService
    {
        List<AdDto> GetAllAds();
        AdDto GetAd(int id);
        void CreateAd(AdDto ad);
        void UpdateAd(AdDto ad, int id);
        void DeleteAd(int id);
    }
}
