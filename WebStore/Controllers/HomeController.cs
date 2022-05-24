using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class HomeController : Controller
{



    public IActionResult Index() => View();


    public IActionResult Greetings(string? id)
    {
        return Content($"Controller Alive - {id}");
    }

   

    public IActionResult Contacts() => View();

    public IActionResult Error404() => View();

    public IActionResult Shop() => View();
   
    public IActionResult ProductDetails() => View();

    public IActionResult Checkout() => View();

    public IActionResult Cart() => View();


    public IActionResult Login() => View();

    public IActionResult Blog() => View();

    public IActionResult BlogSingle() => View();

    public IActionResult ContactUs() => View();



}


