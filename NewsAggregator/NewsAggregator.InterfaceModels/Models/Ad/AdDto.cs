﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.Ad
{
    public class AdDto
    {
        public int Id { get; set; }
        public string AdName { get; set; }
        public string ImageUrl { get; set; }
        public string BannerImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsAdActive { get; set; }
    }
}
