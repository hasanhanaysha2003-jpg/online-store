using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection;
using OnlineStore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, ".dataprotection-keys")));
}
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(2); options.Cookie.HttpOnly = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

// Keep the store pages private until the visitor logs in.
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value?.ToLowerInvariant() ?? string.Empty;
    var publicPath = path.StartsWith("/account") || path.StartsWith("/css") || path.StartsWith("/js") ||
                     path.StartsWith("/lib") || path.StartsWith("/favicon");

    if (!publicPath && string.IsNullOrEmpty(context.Session.GetString("UserName")))
    {
        context.Response.Redirect("/Account/Login");
        return;
    }

    if (path.StartsWith("/admin") && context.Session.GetString("UserRole") != "Admin")
    {
        context.Response.Redirect("/Home/Index");
        return;
    }

    await next();
});
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
    db.Database.EnsureCreated();
    UserInitializer.EnsureUserTable(db);
    DbInitializer.Seed(db);
    SampleImageUpdater.Update(db);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
