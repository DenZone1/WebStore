using Microsoft.AspNetCore.Mvc;

using WebStore.Models;

using WebStore.ViewModels;
using WebStore.Sevices.Interfaces;

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

    public IActionResult Edit(int Id) 
    {
        var employee = _Employees.GetById(Id);
        if (employee is null)
            return NotFound();

        var view_model = new EmployeeViewModel
        {
            Id = employee.Id,
            LastName = employee.LastName,
            Name = employee.Name,
            Patronymic = employee.Patronymic,
            Age = employee.Age,
        };


        return View(view_model);
    }

    [HttpPost]
    public IActionResult Edit(EmployeeViewModel Model) 
    {
        var employee = new Employee
        {
            Id = Model.Id,
            LastName = Model.LastName,
            Name = Model.Name,
            Patronymic = Model.Patronymic,
            Age = Model.Age,
        };

        _Employees.Edit(employee);
        return RedirectToAction(nameof(Index));
    }


    public IActionResult Delete(int Id) => View();



}

