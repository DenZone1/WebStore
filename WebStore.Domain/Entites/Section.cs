using WebStore.Domain.Entites.Base.Interfaces;
using WebStore.Domain.Entites.Base;

namespace WebStore.Domain.Entites;

public class Section : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int? ParentId { get; set; }
}