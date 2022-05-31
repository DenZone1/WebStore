using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Sevices.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers;

public class HomeController : Controller
{



    public IActionResult Index([FromServices] IProductData ProductData)
    {
        var products = ProductData.GetProducts()
            .OrderBy(p => p.Order)
            .Take(6)
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
            });

        ViewBag.Products = products;

        return View();
    }

    public IActionResult Greetings(string? id)
    {
        return Content($"Controller Alive - {id}");
    }

   

    


}


