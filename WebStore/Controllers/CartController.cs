
using WebStore.Sevices.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class CartController : Controller
{
    private readonly ICartService _CartService;
    public CartController(ICartService CartService) { _CartService = CartService; }
   

    public IActionResult Index()
    {
        return View(_CartService.GetViewModel());
    }
}
