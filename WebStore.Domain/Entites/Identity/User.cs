using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entites.Identity;

public class User : IdentityUser
{
    public const string Administrator = "Admin";
    public const string AdminPassword = "123456";
    public override string ToString() => UserName;
    
}
