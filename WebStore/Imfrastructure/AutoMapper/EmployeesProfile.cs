using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using WebStore.Domain.Entites;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Imfrastructure.AutoMapper;

public class EmployeesProfile : Profile
{
    public EmployeesProfile()
    {
        CreateMap<Employee, EmployeeViewModel>()
            .ForMember(m => m.Name, o => o.MapFrom(e =>e.Name))
            .ReverseMap();
    }   

}


