using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.DTO;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.ProductAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly ShopContext _context;

    public ProductsController(ILogger<ProductsController> logger, ShopContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    [Route("products")]
    public IEnumerable<Product> GetProducts()
    {
        var productsDto = from product in _context.Products
                          select new Product()
                          {
                              ProductId = product.Id,
                              Name = product.Name,
                              Description = product.Description,
                              Price = product.Price,
                              CreatedAt = product.CreatedAt,
                              Category = product.Category.Name
                          };
        return productsDto;

    }
    
    [HttpGet("categories",Name = "GetProductCategories")]
    
    public IEnumerable<Category> GetCategories()
    {
        var categoriesDto = from category in _context.Categories
                            select new Category()
                            {
                                CategoryId = category.Id,
                                Name = category.Name,
                                Description = category.Description,
                                CreatedAt = category.CreatedAt,
                            };
        return categoriesDto;

    }
}
