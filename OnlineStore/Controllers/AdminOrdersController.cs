using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
namespace OnlineStore.Controllers;
public class AdminOrdersController(StoreContext db) : Controller { public async Task<IActionResult> Index()=>View(await db.Orders.OrderByDescending(o=>o.OrderDate).ToListAsync()); public async Task<IActionResult> Details(int id){var o=await db.Orders.Include(o=>o.OrderItems).ThenInclude(i=>i.Product).FirstOrDefaultAsync(o=>o.Id==id);return o is null?NotFound():View(o);} [HttpPost] public async Task<IActionResult> ChangeStatus(int id,string status){var o=await db.Orders.FindAsync(id);if(o is null)return NotFound();if(status is "Pending" or "Completed" or "Cancelled") {o.Status=status;await db.SaveChangesAsync();}return RedirectToAction(nameof(Details),new{id});} }
