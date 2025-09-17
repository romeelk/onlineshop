using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Web.UI.Controllers;

public class ProductsController : Controller
{
    private readonly ShopContext _context;

    public ProductsController(ShopContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Products.ToListAsync();
        return View(products);
    }
}