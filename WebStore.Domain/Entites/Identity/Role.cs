using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entites.Identity;

public class Role : IdentityRole
{
    public const string Administrator = "Admin";
    public const string User = "User";
}
