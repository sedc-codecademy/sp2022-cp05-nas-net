using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Exceptions;
using NewsAggregator.Helpers;
using NewsAggregator.InterfaceModels.Models.Category;
using NewsAggregator.Mappers;
using NewsAggregator.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<CategoryDto> GetAll()
        {
            return _categoryRepository.GetAll().Select(x => x.ToCategoryDto()).ToList();
        }
        public CategoryDto GetById(int id)
        {
            var item = _categoryRepository.GetById(id);
            if (item == null)
            {
                throw new CategoryException(404, id, $"Category with ID : {id} does not exist.");
            }
            return item.ToCategoryDto();
        }
        public void Create(CreateCategoryDto model)
        {
            ValidateModel(model.Name);
            var category = new Category(model.Name.Capitalize());
            _categoryRepository.Create(category);
        }
        public void Update(UpdateCategoryDto model, int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new CategoryException(404, id, $"Category with ID : {id} does not exist.");
            }
            ValidateModel(model.Name, id);
            category.Update(model);
            _categoryRepository.Update(category);
        }
        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new CategoryException(404, id, $"Category with ID : {id} does not exist.");
            }
            _categoryRepository.Delete(category);
        }
        private void ValidateModel(string categoryName, int categoryId = 0)
        {
            var categories = _categoryRepository.GetAll();
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new CategoryException(401, "Category name cannot be empty.");
            }
            if (categories.Any(x => x.Name.ToLower() == categoryName.ToLower() && x.Id != categoryId))
            {
                throw new CategoryException(401, $"Category with the name \"{categoryName}\" already exists.");
            }
        }
    }
}
