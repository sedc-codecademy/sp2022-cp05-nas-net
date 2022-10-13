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
        List<AdDto> GetActiveAds();
        AdDto GetAd(int id);
        int CreateAd(CreateAdDto ad);
        void UpdateAd(UpdateAdDto ad, int id);
        bool Toggle(int adId);
        void DeleteAd(int id);
    }
}
