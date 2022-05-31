
using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites;

public class Product : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int SectionId { get; set; }

    public int? BrandId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public decimal Price { get; set; }
}
