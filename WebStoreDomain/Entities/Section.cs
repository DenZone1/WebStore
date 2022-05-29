using WebStoreDomain.Entities.Base;
using WebStoreDomain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities;


public class Section : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int? ParrentId { get; set; }
}

