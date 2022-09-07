using NewsAggregator.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface IPlaceholderService
    {
        List<PlaceholderModel> GetAll();
    }
}
