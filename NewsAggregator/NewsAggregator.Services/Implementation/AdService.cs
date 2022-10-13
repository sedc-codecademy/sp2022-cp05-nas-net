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
            return _adRepository.GetAll().Select(a => a.ToAdDto()).ToList();
        }

        public List<AdDto> GetActiveAds()
        {
            return _adRepository.GetActiveAds().Select(x => x.ToAdDto()).ToList();
        }
        public AdDto GetAd(int id)
        {
            var ad = _adRepository.GetById(id);
            if (ad == null)
            {
                throw new AdException(404, id, $"Ad with ID : {id} does not exist.");
            }
            return ad.ToAdDto();
        }

        public int CreateAd(CreateAdDto model)
        {
            ValidateModel(model.AdName, model.ImageUrl, model.BannerImageUrl, model.RedirectUrl);
            var newAd = new Ad(model.AdName, model.ImageUrl, model.BannerImageUrl, model.RedirectUrl);
            _adRepository.Create(newAd);
            return newAd.Id;
        }

        public void DeleteAd(int id)
        {
            var ad = _adRepository.GetById(id);
            if (ad == null)
            {
                throw new AdException(404, id, $"Ad with ID : {id} does not exist.");
            }
            _adRepository.Delete(ad);
        }
        public void UpdateAd(UpdateAdDto model, int adId)
        {
            var ad = _adRepository.GetById(adId);
            if (ad == null)
            {
                throw new AdException(404, adId, $"Ad with ID : {adId} does not exist.");
            }
            ValidateModel(model.AdName, model.ImageUrl, model.BannerImageUrl, model.RedirectUrl);
            ad.Update(model);
            _adRepository.Update(ad);
        }
        public bool Toggle(int adId)
        {
            var ad = _adRepository.GetById(adId);
            if (ad == null)
            {
                throw new AdException(404, adId, $"Ad with ID : {adId} does not exist.");
            }
            ad.ToggleIsActive();
            _adRepository.Update(ad);
            return ad.IsAdActive;
        }

        private void ValidateModel(string adName, string imageUrl, string bannerImageUrl, string redirectUrl)
        {
            if (string.IsNullOrEmpty(adName))
            {
                throw new AdException(400, "Ad name cannot be empty.");
            }
            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new AdException(400, "Image url cannot be empty.");
            }
            if (!Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                throw new AdException(400, "Please enter a valid image url.");
            }
            if (string.IsNullOrEmpty(bannerImageUrl))
            {
                throw new AdException(400, "Banner image url cannot be empty.");
            }
            if (!Uri.IsWellFormedUriString(bannerImageUrl, UriKind.Absolute))
            {
                throw new AdException(400, "Please enter a valid banner image url.");
            }
            if (string.IsNullOrEmpty(redirectUrl))
            {
                throw new AdException(400, "Redirect url cannot be empty.");
            }
            if (!Uri.IsWellFormedUriString(redirectUrl, UriKind.Absolute))
            {
                throw new AdException(400, "Please enter a valid redirect url.");
            }
        }
    }
}
