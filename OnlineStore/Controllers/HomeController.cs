using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers;

public class HomeController(StoreContext db) : Controller
{
    public async Task<IActionResult> Index() => View(new HomeViewModel { Categories = await db.Categories.ToListAsync(), Products = await db.Products.Include(p => p.Category).Take(6).ToListAsync() });
}
