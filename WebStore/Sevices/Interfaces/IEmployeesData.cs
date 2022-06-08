using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebStore.Domain.Entites;

namespace WebStore.Sevices.Interfaces;

public interface IEmployeesData
{
    int GetCount();

    IEnumerable<Employee> Getall();

    IEnumerable<Employee> Get(int Skip, int Take);

    Employee GetById(int id);

    int Add(Employee employee);

    bool Edit(Employee employee);

    bool Delete(int Id);
}

