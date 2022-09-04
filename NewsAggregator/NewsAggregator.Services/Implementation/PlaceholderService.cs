using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.InterfaceModels.Models;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Implementation
{
    public class PlaceholderService : IPlaceholderService
    {
        private readonly IRepository<Placeholder> _placeholderRepository;

        public PlaceholderService(IRepository<Placeholder> placeholderRepository)
        {
            _placeholderRepository = placeholderRepository;
        }

        public List<PlaceholderModel> GetAll()
        {
           return  _placeholderRepository.GetAll().Select(x => x.ToPlaceholderModel()).ToList();
        }
    }
}
