using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
namespace OnlineStore.Data;
public class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options) { public DbSet<Category> Categories => Set<Category>(); public DbSet<Product> Products => Set<Product>(); public DbSet<Order> Orders => Set<Order>(); public DbSet<OrderItem> OrderItems => Set<OrderItem>(); public DbSet<User> Users => Set<User>(); protected override void OnModelCreating(ModelBuilder b) { b.Entity<Product>().Property(p => p.Price).HasPrecision(10, 2); b.Entity<Order>().Property(o => o.TotalPrice).HasPrecision(10, 2); b.Entity<OrderItem>().Property(i => i.UnitPrice).HasPrecision(10, 2); } }
