using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Web.UI.Models;

namespace OnlineShop.Web.UI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController( IProductService productService)
    {
        _productService= productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProductsAsync();

        var productViewModel = products.Select(p => new ProductViewModel()
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            Category = p.Category
        });

        return View(productViewModel);
    }
}