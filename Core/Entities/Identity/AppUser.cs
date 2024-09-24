using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Role { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public string? Bio { get; set; }

    public DateTime? CreatedAt { get; set; }
}