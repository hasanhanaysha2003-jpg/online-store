using OnlineStore.Models;
namespace OnlineStore.ViewModels;
public class ProductsViewModel { public List<Product> Products { get; set; } = []; public List<Product> SimilarProducts { get; set; } = []; public List<Category> Categories { get; set; } = []; public string? Search { get; set; } public int? CategoryId { get; set; } }
