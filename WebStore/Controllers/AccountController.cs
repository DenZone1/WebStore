using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebStore.Domain.Entites.Identity;

namespace WebStore.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> _UserMAnager;
    private readonly SignInManager<User> _SignInManager;
    private readonly ILogger<AccountController> _Logger;

    public AccountController(
        UserManager<User> UserMAnager,
        SignInManager<User> SignInManager,
        ILogger<AccountController> Logger)
    {
        _UserMAnager = UserMAnager;
        _SignInManager = SignInManager;
        _Logger = Logger;
    }

    public IActionResult Register() => View();

    public IActionResult Login() => View();

    public IActionResult Logout() => View();

    public IActionResult AccesDenied() => View();
}
