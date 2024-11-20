namespace NTierArchitecture.Entities.Models
{
    public sealed class Category
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
