

using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entites.Idnetity;

public class User : IdentityUser
{
    public override string ToString() => UserName;
    
}


