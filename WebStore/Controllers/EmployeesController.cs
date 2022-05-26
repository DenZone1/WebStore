using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Sevices;
using WebStore.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebStore.Imfrastructure.Middleware;
using WebStore.Imfrastructure.Conventions;
using WebStore.Models;

namespace WebStore.Controllers;
//[Route("Staff/{action=Index}/{Id?}")]//переопределение маршрута
public class EmployeesController : Controller
{
    private readonly IEmployeesData _Employees;

    public EmployeesController(IEmployeesData Employees)
    {
        _Employees = Employees;
    }

    public IActionResult Index()
    {
        var employees = _Employees.Getall();
        return View(employees);

    }


    //[Route("[controller]/Info/{Id}")] //переопределенияе маршрута для конкретного действия
    public IActionResult Details(int Id)
    {
        var employee = _Employees.GetById(Id);
        if (employee is null)
            return NotFound();

        return View(employee);
    }


    public IActionResult Create() => View();
    public IActionResult Edit(int Id) => View();
    public IActionResult Delete(int Id) => View();



}

