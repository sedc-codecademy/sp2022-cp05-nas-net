using NewsAggregator.InterfaceModels.Models.Ad;
using NewsAggregator.Services.Abstraction;
using NewsAggregator.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.Mappers;
using System.Security.Cryptography.X509Certificates;
using NewsAggregator.DataAccess.Repositories;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;

namespace NewsAggregator.Services.Implementation
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _adRepository;
        public AdService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public List<AdDto> GetAllAds()
        {
            return _adRepository.GetAll().Select(a => AdMapper.ToAdDto(a)).ToList();
        }
        public AdDto GetAd(int id)
        {
            var ad = _adRepository.GetAll().Where(x => x.Id == id)
                                   .FirstOrDefault()
                                   ?? throw new Exception("Ad not found");
            return ad.ToAdDto();
        }

        public void CreateAd(AdDto model)
        {
            //To do
            throw new Exception("Not implemented");
        }

        public void DeleteAd(int id)
        {
            var ad = _adRepository.GetById(id) ?? throw new Exception("Ad not found"); 

            _adRepository.Delete(ad);
        }
        public void UpdateAd(AdDto model, int adId)
        {
            var ad = _adRepository.GetById(adId);
            if (ad == null)
            {
                throw new UserException(404, adId, "The ad does not exist");
            }
            ad.Update(model);
            _adRepository.Update(ad);
        }
    }
}
