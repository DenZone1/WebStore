using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}