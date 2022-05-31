using WebStore.Domain;

using WebStore.Domain.Entites;

namespace WebStore.Sevices.Interfaces;

public interface IProductData
{   
    IEnumerable<Section> GetSections();
    IEnumerable<Brand> GetBrands();

    IEnumerable<Product> GetProducts(ProductFilter? Filter = null);

}
