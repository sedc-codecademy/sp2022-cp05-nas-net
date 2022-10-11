using NewsAggregator.Domain.Interfaces;
using NewsAggregator.Helpers;
using NewsAggregator.InterfaceModels.Models.Category;

namespace NewsAggregator.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category() { }
        public Category(string name)
        {
            Name = name;
        }
        public void Update(UpdateCategoryDto model)
        {
            Name = model.Name.Capitalize();
        }
    }
}