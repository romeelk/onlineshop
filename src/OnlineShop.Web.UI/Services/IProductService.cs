using OnlineShop.DTO;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync();
    Task<List<Category>> GetCategoriesAsync();
}