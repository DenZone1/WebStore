using WebStore.Data;
using WebStore.Models;
using WebStore.Sevices.Interfaces;

namespace WebStore.Sevices;

public class InMemoryEmployeesData : IEmployeesData
{
    private readonly ILogger<InMemoryEmployeesData> _Logger;
    private readonly ICollection<Employee> _Employees;
    private int _LastFreeId;

    public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> Logger)
    {
       
        _Employees = TestData.Employees;
        _Logger = Logger;

        if(_Employees.Count >0)//вычисление последнего свободного Id
            _LastFreeId = _Employees.Max(e => e.Id)+1;
        else
            _LastFreeId = 1;
    }

    public int Add(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        if (_Employees.Contains(employee))//только для хранения данных в памяти(есил есть БД то не надо)
            return employee.Id;

        employee.Id = _LastFreeId;  //не делать если есть БД
        _LastFreeId++;              //не делать если есть БД

        return employee.Id; //если есть БД то вызвать SaveChanges()

    }

    public bool Delete(int Id)
    {
        var employee = GetById(Id);
        if (employee is null)
            return false;

        _Employees.Remove(employee);
        return true;

    }

    public bool Edit(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));
        if (_Employees.Contains(employee))//только для хранения данных в памяти(есил есть БД то не надо)
            return true;

        var db_employee = GetById(employee.Id);
            if(db_employee is null)
            return false;

        db_employee.Id = employee.Id;
        db_employee.LastName = employee.LastName;
        db_employee.Name = employee.Name;
        db_employee.Patronymic = employee.Patronymic;
        db_employee.Age = employee.Age;
        //если есть БД то вызвать SaveChanges()
        return true;

    }

    public IEnumerable<Employee> Getall()
    {
       return _Employees;
    }

    public Employee GetById(int id)
    {
       var employee = _Employees.FirstOrDefault(e =>e.Id==id);
        return employee;
    }
}

