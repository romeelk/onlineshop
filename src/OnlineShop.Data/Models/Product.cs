namespace OnlineShop.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set;}
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}