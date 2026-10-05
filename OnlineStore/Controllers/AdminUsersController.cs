using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

namespace OnlineStore.Controllers;

public class AdminUsersController(StoreContext db) : Controller
{
    public async Task<IActionResult> Index() => View(await db.Users.OrderBy(u => u.Role).ThenBy(u => u.Name).ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var user = await db.Users.FindAsync(id);
        return user is null ? NotFound() : View(user);
    }
}
