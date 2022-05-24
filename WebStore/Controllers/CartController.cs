using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Models;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
