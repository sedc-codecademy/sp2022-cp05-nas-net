using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.Ad
{
    public class AdDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string AltText { get; set; }
        public bool IsAdActive { get; set; }

        public int UserId { get; set; }
    }
}
