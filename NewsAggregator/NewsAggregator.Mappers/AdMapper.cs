using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models.Ad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Mappers
{
    public static class AdMapper
    {
        public static AdDto ToAdDto(this Ad ad)
        {
            return new()
            {
                Id = ad.Id,
                ImageUrl = ad.ImageUrl,
                RedirectUrl = ad.RedirectUrl,
                AltText = ad.AltText,
                IsAdActive = ad.IsAdActive
            };
        }
    }
}
