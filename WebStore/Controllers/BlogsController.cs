
using Microsoft.AspNetCore.Mvc;

using WebStore.Sevices.Interfaces;

namespace WebStore.Controllers;

public class BlogsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details()
    {
        return View();
    }
}