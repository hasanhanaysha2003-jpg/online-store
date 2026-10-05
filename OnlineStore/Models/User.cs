using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models;

public class User
{
    public int Id { get; set; }

    [Required, StringLength(60)]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 4)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
}
