using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entites.Identity;

public class User : IdentityUser
{
    public override string ToString() => UserName;
    
}
