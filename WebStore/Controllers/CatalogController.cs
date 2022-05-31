using WebStore.Domain;
using WebStore.Sevices.Interfaces;
using WebStore.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class CatalogController : Controller 
{
    public IActionResult Index()
    {
        return View();
    }
}
