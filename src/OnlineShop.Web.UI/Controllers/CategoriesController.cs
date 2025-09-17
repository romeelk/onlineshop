using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Web.UI.Controllers;

public class CategoriesController : Controller
{
    private readonly ShopContext _context;

    public CategoriesController(ShopContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _context.Categories.ToListAsync();
        return View(products);
    }
}