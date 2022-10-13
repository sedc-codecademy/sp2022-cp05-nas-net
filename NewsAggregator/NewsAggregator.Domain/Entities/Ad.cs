using NewsAggregator.Domain.Interfaces;
using NewsAggregator.InterfaceModels.Models.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Domain.Entities
{
    public class Ad : IEntity
    {
        public int Id { get; set; }
        public string AdName { get; set; }
        public string ImageUrl { get; set; }
        public string BannerImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsAdActive { get; set; }
        public Ad(string adName, string imageUrl, string bannerImageUrl, string redirectUrl)
        {
            AdName = adName;
            ImageUrl = imageUrl;
            BannerImageUrl = bannerImageUrl;
            RedirectUrl = redirectUrl;
            IsAdActive = true;
        }
        public void Update(UpdateAdDto model)
        {
            AdName = model.AdName;
            ImageUrl = model.ImageUrl;
            BannerImageUrl = model.BannerImageUrl;
            RedirectUrl = model.RedirectUrl;
        }

        public void ToggleIsActive()
        {
            IsAdActive = !IsAdActive;
        }
    }
}
