namespace OnlineShop.Web.UI.Models;

public class ProductViewModel
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set;}
    public string Category { get; set; }
}
