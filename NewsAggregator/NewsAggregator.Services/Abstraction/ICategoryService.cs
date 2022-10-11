using NewsAggregator.InterfaceModels.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Abstraction
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        int Create(CreateCategoryDto model);
        void Update(UpdateCategoryDto model, int id);
        void Delete(int id);
    }
}
