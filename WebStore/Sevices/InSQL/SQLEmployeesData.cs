using WebStore.DAL.Context;
using WebStore.DAL.Migrations;
using WebStore.Domain.Entites;
using WebStore.Sevices.Interfaces;

namespace WebStore.Sevices.InSQL;

public class SQLEmployeesData : IEmployeesData
{
    private readonly WebStoreDB _db;
    private readonly ILogger<SQLEmployeesData> _Logger;

    public SQLEmployeesData(WebStoreDB db, ILogger<SQLEmployeesData> Logger)
    {
        _db = db;
        _Logger = Logger;
    }

    public int Add(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));



        _db.Employees.Add(employee);
        _db.SaveChanges();

        _Logger.LogInformation("Employee {0} added", employee);
        return employee.Id; //если есть БД то вызвать SaveChanges()
    }

    public bool Delete(int Id)
    {
        // var employee = GetById(Id);
        var employee = _db.Employees
            .Select(e => new Employee { Id = e.Id })
            .FirstOrDefault(e => e.Id == Id);

        if (employee is null)
        {
            _Logger.LogWarning("Employee with ID:{0} - doesn`t exist", Id);
            return false;
        }

        _db.Remove(employee);
        _db.SaveChanges();
        return true;

    }

    public bool Edit(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));


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
        _db.SaveChanges();
        _Logger.LogInformation("Employee {0} changed", employee);
        return true;
    }

  
    public IEnumerable<Employee> Getall() => _db.Employees;


    // public Employee? GetById(int id)=> _db.Employees.FirstOrDefault(e => e.Id == id);
    // public Employee? GetById(int id) => _db.Employees.SingleOrDefault(e => e.Id == id);
    public Employee? GetById(int id) => _db.Employees.Find(id);

    public int GetCount()=> _db.Employees.Count();
  
    public IEnumerable<Employee> Get(int Skip, int Take)
    {
        IQueryable<Employee> query = _db.Employees;
        if (Take == 0) return Enumerable.Empty<Employee>();


        if(Skip>0)
            query = query.Skip(Skip);
        return query.Take(Take);
    }

}
