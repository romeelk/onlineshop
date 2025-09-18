using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Web.UI.Models;

namespace OnlineShop.Web.UI.Controllers;

public class CategoriesController : Controller
{
    private readonly IProductService _productService;
    public CategoriesController( IProductService productService)
    {
        _productService= productService;
    }

      public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProductsAsync();

        var productViewModel = products.Select(p => new CategoryViewModel()
        {
            CategoryId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            CreatedAt= p.CreatedAt
        });

        return View(productViewModel);
    }
}