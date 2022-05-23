using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class BlogsController : Controller
{
    public IActionResult Index() => View();//должен вернуть представление списка блогов - blog.html

    public IActionResult ShopBlog() => View();//олжен вернуть представление списка блого - blog-single.html
}