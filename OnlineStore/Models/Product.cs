using System.ComponentModel.DataAnnotations;
namespace OnlineStore.Models;
public class Product { public int Id { get; set; } [Required, StringLength(100)] public string Name { get; set; } = string.Empty; [StringLength(500)] public string Description { get; set; } = string.Empty; [Range(0.01, 100000)] public decimal Price { get; set; } [StringLength(500)] public string ImageUrl { get; set; } = "https://placehold.co/600x400?text=Product"; [Range(0, 10000)] public int StockQuantity { get; set; } public int CategoryId { get; set; } public Category? Category { get; set; } }
