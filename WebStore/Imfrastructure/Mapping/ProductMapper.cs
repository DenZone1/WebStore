

using WebStore.Domain.Entites;
using WebStore.ViewModels;

namespace WebStore.Imfrastructure.Mapping;

public static class ProductMapper
{
    public static ProductViewModel? ToView(this Product? product) => product is null
        ? null
        : new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            ImageUrl = product.ImageUrl,
        };

    public static IEnumerable<ProductViewModel?> ToView(this IEnumerable<Product?> products) =>
        products.Select(p => p.ToView());
}
