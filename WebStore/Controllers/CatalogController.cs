using WebStore.Domain;
using WebStore.Sevices.Interfaces;
using WebStore.ViewModels;
using WebStore.Imfrastructure.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers;

public class CatalogController : Controller 
{
    private readonly IProductData _ProductData;

    public CatalogController(IProductData productData) => _ProductData = productData;

    public IActionResult Index([Bind("SectionId,BrandId")]ProductFilter filter)//[Bind("")] - фильтр свойств доступных пользователю
    {
       
        var products = _ProductData.GetProducts(filter);

        return View(new CatalogViewModel
        {
            BrandId = filter.BrandId,
            SectionId = filter.SectionId,
            Products = products
               .OrderBy(p => p.Order).ToView()!,
        });
    }
}
