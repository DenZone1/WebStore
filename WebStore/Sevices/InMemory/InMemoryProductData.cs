using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entites;
using WebStore.Sevices.Interfaces;

namespace WebStore.Sevices.InMemory;

[Obsolete]
public class InMemoryProductData : IProductData
{
    public IEnumerable<Section> GetSections() => TestData.Sections;

    public IEnumerable<Brand> GetBrands() => TestData.Brands;

    public IEnumerable<Product> GetProducts(ProductFilter? Filter = null)
    {
        IEnumerable<Product> query = TestData.Products;

        if (Filter is { SectionId: { } section_id })
            query = query.Where(x => x.SectionId == section_id);

        if (Filter is { BrandId: { } brand_id })
            query = query.Where(x => x.BrandId == brand_id);

        return query;
    }

    public Section? GetSectionById(int id)
    {
        throw new NotImplementedException();
    }

    public Brand? GetBrandById(int id)
    {
        throw new NotImplementedException();
    }

    public Product? GetProductById(int id)
    {
        throw new NotImplementedException();
    }
}
