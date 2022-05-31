
using WebStore.Data;
using WebStore.Domain.Entites;
using WebStore.Sevices.Interfaces;

namespace WebStore.Sevices;

public class InMemoryProductData : IProductData
{
    public IEnumerable<Section> GetSections() => TestData.Sections;
  
    public IEnumerable<Brand> GetBrands() => TestData.Brands;
   

   
}
