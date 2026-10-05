namespace OnlineStore.Data;

public static class SampleImageUpdater
{
    public static void Update(StoreContext db)
    {
        var urls = new Dictionary<string, string>
        {
            ["Wireless Mouse"] = "https://images.unsplash.com/photo-1527814050087-3793815479db?auto=format&fit=crop&w=600&q=80",
            ["Keyboard"] = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?auto=format&fit=crop&w=600&q=80",
            ["Headphones"] = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&w=600&q=80",
            ["T-Shirt"] = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=600&q=80",
            ["Hoodie"] = "https://images.unsplash.com/photo-1556821840-3a63f95609a7?auto=format&fit=crop&w=600&q=80",
            ["Jeans"] = "https://images.unsplash.com/photo-1542272604-787c3835535d?auto=format&fit=crop&w=600&q=80",
            ["C# Basics"] = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?auto=format&fit=crop&w=600&q=80",
            ["Web Development"] = "https://images.unsplash.com/photo-1498050108023-c5249f4df085?auto=format&fit=crop&w=600&q=80",
            ["Database Fundamentals"] = "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?auto=format&fit=crop&w=600&q=80"
        };

        foreach (var product in db.Products)
            if (urls.TryGetValue(product.Name, out var url)) product.ImageUrl = url;

        db.SaveChanges();
    }
}
