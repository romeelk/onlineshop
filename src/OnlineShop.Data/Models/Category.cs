namespace OnlineShop.Data.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }

     // Collection navigation property
    public ICollection<Product> Products { get; set; }
}