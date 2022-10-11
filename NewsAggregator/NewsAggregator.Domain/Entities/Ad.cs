<<<<<<< HEAD
﻿using NewsAggregator.Domain.Interfaces;
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
        public int Id { get; set ; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string AltText { get; set; }
        public bool IsAdActive { get; set; }
        public Ad(string imageUrl, string redirectUrl, string altText, bool isAdActive)
        {
            ImageUrl = imageUrl;
            RedirectUrl = redirectUrl;
            AltText = altText;
            IsAdActive = isAdActive;
            IsAdActive = isAdActive;
        }

        public void Update(AdDto model)
        {
            ImageUrl = model.ImageUrl;
            RedirectUrl = model.RedirectUrl;
            AltText = model.AltText;
            IsAdActive = model.IsAdActive;
        }
    }
}
=======
﻿using NewsAggregator.Domain.Interfaces;
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
        public int Id { get; set ; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string AltText { get; set; }
        public bool IsAdActive { get; set; }
        public Ad(string imageUrl, string redirectUrl, string altText, bool isAdActive)
        {
            ImageUrl = imageUrl;
            RedirectUrl = redirectUrl;
            AltText = altText;
            IsAdActive = isAdActive;
            IsAdActive = isAdActive;
        }

        public void Update(AdDto model)
        {
            ImageUrl = model.ImageUrl;
            RedirectUrl = model.RedirectUrl;
            AltText = model.AltText;
            IsAdActive = model.IsAdActive;
        }
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
