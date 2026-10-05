using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.ViewModels;

namespace OnlineStore.Controllers;

public class AccountController(StoreContext db) : Controller
{
    public IActionResult Register() => View(new User());

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (await db.Users.AnyAsync(u => u.Email == user.Email))
            ModelState.AddModelError("Email", "This email is already registered.");

        if (!ModelState.IsValid) return View(user);

        user.Role = "User";
        db.Users.Add(user);
        await db.SaveChangesAsync();
        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetString("UserRole", user.Role);
        TempData["Message"] = "Your account was created successfully.";
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
        if (user is null)
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        HttpContext.Session.SetString("UserName", user.Name);
        HttpContext.Session.SetString("UserRole", user.Role);
        TempData["Message"] = $"Welcome, {user.Name}!";
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserName");
        HttpContext.Session.Remove("UserRole");
        TempData["Message"] = "You have logged out.";
        return RedirectToAction("Index", "Home");
    }
}
