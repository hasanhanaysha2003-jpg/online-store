using OnlineStore.Models;
namespace OnlineStore.ViewModels;
public class CartViewModel { public List<CartItem> Items { get; set; } = []; public decimal Total => Items.Sum(x => x.Subtotal); }
