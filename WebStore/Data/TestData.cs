using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebStore.Models;

namespace WebStore.Data;

public class TestData
{
    public static ICollection<Employee> Employees { get; } =  new List<Employee>
    {
        new() {Id = 1, LastName = "Ivanov", Name ="Petr", Patronymic="Vasyl`evich", Age="57" },
        new() {Id = 2, LastName = "Petrov", Name ="Ivan", Patronymic="Sydorovisch", Age="18" },
        new() {Id = 3, LastName = "Pilat", Name ="Pontyi", Patronymic="Rimskii", Age="85" },
    };
}