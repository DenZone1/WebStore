using WebStore.Domain;

using WebStore.Domain.Entites;

namespace WebStore.Sevices.Interfaces;

public interface IProductData
{   
    IEnumerable<Section> GetSections();
    Section? GetSectionById(int id);

    IEnumerable<Brand> GetBrands();
    Brand? GetBrandById(int id);

    IEnumerable<Product> GetProducts(ProductFilter? Filter = null);
    Product? GetProductById(int id);

}
