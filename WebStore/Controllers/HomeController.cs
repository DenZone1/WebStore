using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers;

    public class HomeController : Controller
    {

        private static readonly List<Employee> __Employees = new()
        {
            new Employee {Id = 1, LastName = "Ivanov", Name ="Petr", Patronymic="Vasyl`evich", Age="57" },
            new Employee {Id = 2, LastName = "Petrov", Name ="Ivan", Patronymic="Sydorovisch", Age="18" },
            new Employee {Id = 3, LastName = "Pilat", Name ="Pontyi", Patronymic="Rimskii", Age="85" },
        };


        public IActionResult Index()
        {
            return View();
            //return Content("Index");
        }

        public IActionResult Greetings(string? id)
        {
            return Content($"Controller Alive - {id}");
        }

        public IActionResult Emloyees()
        {
            return View(__Employees);
        }
        public IActionResult EmployeeDetails(int Id)
        {
            var employee = __Employees.FirstOrDefault(x => x.Id == Id);
            return View();
        }


    }


