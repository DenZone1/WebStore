using WebStore.Domain;
using WebStore.Sevices.Interfaces;
using WebStore.ViewModels;
using WebStore.Imfrastructure.Mapping;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebStore.Controllers;

public class CatalogController : Controller 
{
    private readonly IProductData _ProductData;
    private readonly IMapper _Mapper;

    public CatalogController(IProductData productData, IMapper Mapper)
    {
        _ProductData = productData;
        _Mapper = Mapper;
    }

    public IActionResult Index([Bind("SectionId,BrandId")]ProductFilter filter)//[Bind("")] - фильтр свойств доступных пользователю
    {
       
        var products = _ProductData.GetProducts(filter);

        return View(new CatalogViewModel
        {
            BrandId = filter.BrandId,
            SectionId = filter.SectionId,
            Products = products.OrderBy(p => p.Order).Select(p => _Mapper.Map<ProductViewModel>(p)),//использование автомеппера
            //Products = products.OrderBy(p => p.Order).ToView()!, вручную
        });
    }
}
