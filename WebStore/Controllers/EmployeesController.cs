using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WebStore.Models;

namespace WebStore.Controllers;
//[Route("Staff/{action=Index}/{Id?}")]//переопределение маршрута
public class EmployeesController : Controller
{

    private static readonly List<Employee> __Employees = new()
    {
        new Employee {Id = 1, LastName = "Ivanov", Name ="Petr", Patronymic="Vasyl`evich", Age="57" },
        new Employee {Id = 2, LastName = "Petrov", Name ="Ivan", Patronymic="Sydorovisch", Age="18" },
        new Employee {Id = 3, LastName = "Pilat", Name ="Pontyi", Patronymic="Rimskii", Age="85" },
    };


    public IActionResult Index()
    {
        return View(__Employees);

    }


    //[Route("[controller]/Info/{Id}")] //переопределенияе маршрута для конкретного действия
    public IActionResult Details(int Id)
    {
        var employee = __Employees.FirstOrDefault(x => x.Id == Id);
        if (employee is null)
            return NotFound();

        return View(employee);
    }

    
}

