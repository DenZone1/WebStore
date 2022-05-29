using WebStoreDomain.Entities.Base;
using WebStoreDomain.Entities.Base.Interfaces;

namespace WebStoreDomain.Entities;

public class Brand : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }
}

public class Section : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int? ParrentId { get; set; }
}


