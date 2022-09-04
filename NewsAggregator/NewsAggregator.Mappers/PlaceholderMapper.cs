using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Mappers
{
    public static class PlaceholderMapper
    {
        public static Placeholder ToPlaceholder (this PlaceholderModel model)
        {
            return new Placeholder
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static PlaceholderModel ToPlaceholderModel (this Placeholder model)
        {
            return new PlaceholderModel
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

    }
}
