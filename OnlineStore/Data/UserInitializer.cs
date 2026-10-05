using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace OnlineStore.Data;

public static class UserInitializer
{
    public static void EnsureUserTable(StoreContext db)
    {
        db.Database.ExecuteSqlRaw("CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, Email TEXT NOT NULL, Password TEXT NOT NULL, Role TEXT NOT NULL DEFAULT 'User')");
        using var connection = db.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA table_info(Users)";
        using var reader = command.ExecuteReader();
        var hasRole = false;
        while (reader.Read()) if (reader.GetString(1) == "Role") hasRole = true;
        connection.Close();
        if (!hasRole) db.Database.ExecuteSqlRaw("ALTER TABLE Users ADD COLUMN Role TEXT NOT NULL DEFAULT 'User'");
        if (!db.Users.Any(u => u.Email == "admin@onlinestore.com"))
        {
            db.Users.Add(new User { Name = "Store Admin", Email = "admin@onlinestore.com", Password = "Admin123", Role = "Admin" });
            db.SaveChanges();
        }
    }
}
