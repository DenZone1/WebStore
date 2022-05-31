﻿using Microsoft.AspNetCore.Mvc;

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


    public IActionResult Create() => View("Edit", new EmployeeViewModel());

    public IActionResult Edit(int? Id) 
    {

        if (Id == null)
        return View(new EmployeeViewModel());


        var employee = _Employees.GetById((int)Id);
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
        if (Model.LastName == "Qwe" && Model.Name == "Qwe" && Model.Patronymic == "Qwe")
            ModelState.AddModelError("", "Qwe - bad choice");

        if (Model.Name == "Asd")
            ModelState.AddModelError("Name", "Name - error");
        
        if(!ModelState.IsValid)
            return View(Model);

        var employee = new Employee
        {
            Id = Model.Id,
            LastName = Model.LastName,
            Name = Model.Name,
            Patronymic = Model.Patronymic,
            Age = Model.Age,
        };
        if (Model.Id==0)
        {
            var new_employee_id  =_Employees.Add(employee);
            return RedirectToAction(nameof(Details), new {Id = new_employee_id  });
        }

        _Employees.Edit(employee);
        return RedirectToAction(nameof(Index));
    }


    public IActionResult Delete(int Id)
    {
        // _Employees.Delete(Id);                      //нельзя использовать
        // return RedirectToAction(nameof(Index));     //нельзя использовать
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
    public IActionResult DeleteConfirmed(int Id)
    {
        if(!_Employees.Delete(Id))
            return NotFound();

        return RedirectToAction(nameof(Index));
    }



}

