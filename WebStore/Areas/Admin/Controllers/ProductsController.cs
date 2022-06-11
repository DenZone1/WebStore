using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using WebStore.Domain.Entites.Identity;

namespace WebStore.Areas.Admin.Controllers;

[Authorize(Roles = Role.Administrator)]
public class ProductsController : Controller
{
    public IActionResult Index() => View();
}
