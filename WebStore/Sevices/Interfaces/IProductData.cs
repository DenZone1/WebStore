

using WebStore.Domain.Entites;

namespace WebStore.Sevices.Interfaces;

public interface IProductData
{   
    IEnumerable<Section> GetSections();
    IEnumerable<Brand> GetBrands();


}
