using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebStore.Domain.Entites.Identity;
using WebStore.ViewModels.Identity;

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

    public IActionResult Register() => View(new RegisterUserViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserViewModel Model)
    {
        if(ModelState.IsValid)
            return View(Model);

        var user = new User
        {
            UserName = Model.UserName,
        };

        var creation_result = await _UserMAnager.CreateAsync(user,Model.Password);
        if (creation_result.Succeeded)
        {
            _Logger.LogInformation("User {0} Registered", user);

            await _SignInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }
        foreach (var error in creation_result.Errors)
            ModelState.AddModelError("", error.Description);

        var error_info = string.Join(", ", creation_result.Errors.Select(e => e.Description));
        _Logger.LogWarning("Error User Registation {0}:{1}",user, error_info);

        return View(Model);
    }

    public IActionResult Login(string? ReturnUrl) => View( new LoginViewModel {ReturnUrl = ReturnUrl });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel Model)
    {
        if (!ModelState.IsValid)
            return View(Model);

        var login_result = await _SignInManager.PasswordSignInAsync(
            Model.UserName,
            Model.Password,
            Model.RememberMe,
            lockoutOnFailure : true);

        if (login_result.Succeeded)
        {
            _Logger.LogInformation("User {0} Enter the system", Model.UserName);

            //if (Url.IsLocalUrl(Model.ReturnUrl))
            //    return Redirect(Model.ReturnUrl);
            //return RedirectToAction("Index", "Home");
            return LocalRedirect(Model.ReturnUrl ?? "/");
        }

        ModelState.AddModelError("", "Invalid User Name or Password");
        _Logger.LogWarning("Error enter the system {0} Invalid User Name or Password", Model.UserName);

        return View(Model);

    }

    public IActionResult Logout() => View();

    public IActionResult AccesDenied() => View();
}
