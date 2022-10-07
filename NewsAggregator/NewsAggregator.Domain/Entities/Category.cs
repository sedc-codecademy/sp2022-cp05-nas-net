namespace NewsAggregator.Domain.Entities
{
    public class Category : IEntity
    { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IList<Article> Articles { get; set; } = new List<Article>();
    }
}