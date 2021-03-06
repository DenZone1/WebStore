using WebStore.Data;
using WebStore.Domain.Entites;
using WebStore.Sevices.Interfaces;

namespace WebStore.Sevices.InMemory;

public class InMemoryEmployeesData : IEmployeesData
{
    private readonly ILogger<InMemoryEmployeesData> _Logger;
    private readonly ICollection<Employee> _Employees;
    private int _LastFreeId;

    public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> Logger)
    {

        _Employees = TestData.Employees;
        _Logger = Logger;

        if (_Employees.Count > 0)//вычисление последнего свободного Id
            _LastFreeId = _Employees.Max(e => e.Id) + 1;
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

        _Employees.Add(employee);

        _Logger.LogInformation("Employee {0} added", employee);
        return employee.Id; //если есть БД то вызвать SaveChanges()

    }

    public bool Delete(int Id)
    {
        var employee = GetById(Id);
        if (employee is null)
        {
            _Logger.LogWarning("Employee with ID:{0} - doesn`t exist", Id);
            return false;
        }


        _Employees.Remove(employee);
        _Logger.LogInformation("Employee {0} deleted", employee);
        return true;

    }

    public bool Edit(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));
        if (_Employees.Contains(employee))//только для хранения данных в памяти(есил есть БД то не надо)
            return true;

        var db_employee = GetById(employee.Id);
        if (db_employee is null)
        {
            _Logger.LogWarning("Employee {0} - doesn`t exist", employee);
            return false;
        }


        db_employee.Id = employee.Id;
        db_employee.LastName = employee.LastName;
        db_employee.Name = employee.Name;
        db_employee.Patronymic = employee.Patronymic;
        db_employee.Age = employee.Age;
        //если есть БД то вызвать SaveChanges()
        _Logger.LogInformation("Employee {0} changed", employee);
        return true;

    }

    

    public IEnumerable<Employee> Getall()
    {
        return _Employees;
    }

    public Employee GetById(int id)
    {
        var employee = _Employees.FirstOrDefault(e => e.Id == id);
        return employee;
    }

    public int GetCount()
    {
        return _Employees.Count;
    }
    public IEnumerable<Employee> Get(int Skip, int Take)
    {
        IEnumerable<Employee>  query = _Employees;
        
        if (Take == 0) return Enumerable.Empty<Employee>();

        if (Skip > 0)
        {
            if(Skip > _Employees.Count) return Enumerable.Empty<Employee>();

            query = query.Skip(Skip);
        }
           return query = query.Take(Take);


    }
}

