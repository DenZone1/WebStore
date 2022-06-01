using WebStore.Domain;
using WebStore.Sevices.Interfaces;
using WebStore.ViewModels;

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
               .OrderBy(p => p.Order)
               .Select(p => new ProductViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Price = p.Price,
                   ImageUrl = p.ImageUrl,
               }),
        });
    }
}
