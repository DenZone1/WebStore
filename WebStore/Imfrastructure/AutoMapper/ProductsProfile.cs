using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using WebStore.Domain.Entites;
using WebStore.ViewModels;

namespace WebStore.Imfrastructure.AutoMapper;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Product, ProductViewModel>();
    }
}