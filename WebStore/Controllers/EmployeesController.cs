using Microsoft.AspNetCore.Mvc;

using WebStore.ViewModels;
using WebStore.Sevices.Interfaces;
using WebStore.Imfrastructure.Mapping;
using AutoMapper;
using WebStore.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using WebStore.Domain.Entites.Identity;

namespace WebStore.Controllers;
//[Route("Staff/{action=Index}/{Id?}")]//переопределение маршрута
[Authorize]
public class EmployeesController : Controller
{
    private readonly IEmployeesData _Employees;
    private readonly IMapper _Mapper;

    public EmployeesController(IEmployeesData Employees, IMapper Mapper)
    {
        _Employees = Employees;
        _Mapper = Mapper;
    }

    public IActionResult Index(int? Page, int PageSize = 15)
    {
        //var employees = _Employees.Getall();

        IEnumerable<Employee> employees;
        if (Page is { } page && PageSize > 0)
        {
            employees = _Employees.Get(page * PageSize, PageSize);
        }
        else
            employees = _Employees.Getall();

        ViewBag.PagesCount = PageSize > 0 ?
            (int?)Math.Ceiling(_Employees.GetCount() / (double)PageSize)
            : null!;

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

    [Authorize(Roles = Role.Administrator)]
    public IActionResult Create() => View("Edit", new EmployeeViewModel());

    [Authorize(Roles = Role.Administrator)]
    public IActionResult Edit(int? Id) 
    {

        if (Id == null)
        return View(new EmployeeViewModel());


        var employee = _Employees.GetById((int)Id);
        if (employee is null)
            return NotFound();

        // var view_model = employee.ToView(); вручную

        var view_model = _Mapper.Map<EmployeeViewModel>(employee);

        //var view_model = new EmployeeViewModel
        //{
        //    Id = employee.Id,
        //    LastName = employee.LastName,
        //    Name = employee.Name,
        //    Patronymic = employee.Patronymic,
        //    Age = employee.Age,
        //};


        return View(view_model);
    }

    [HttpPost]
    [Authorize(Roles = Role.Administrator)]
    public IActionResult Edit(EmployeeViewModel Model) 
    {
        if (Model.LastName == "Qwe" && Model.Name == "Qwe" && Model.Patronymic == "Qwe")
            ModelState.AddModelError("", "Qwe - bad choice");

        if (Model.Name == "Asd")
            ModelState.AddModelError("Name", "Name - error");
        
        if(!ModelState.IsValid)
            return View(Model);

        var employee = _Mapper.Map<Employee>(Model);

        // var employee = Model.FromView(); вручную

        //var employee = new Employee
        //{
        //    Id = Model.Id,
        //    LastName = Model.LastName,
        //    Name = Model.Name,
        //    Patronymic = Model.Patronymic,
        //    Age = Model.Age,
        //};
        if (Model.Id==0)
        {
            var new_employee_id  =_Employees.Add(employee);
            return RedirectToAction(nameof(Details), new {Id = new_employee_id  });
        }

        _Employees.Edit(employee);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = Role.Administrator)]
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
    [Authorize(Roles = Role.Administrator)]
    public IActionResult DeleteConfirmed(int Id)
    {
        if(!_Employees.Delete(Id))
            return NotFound();

        return RedirectToAction(nameof(Index));
    }



}

