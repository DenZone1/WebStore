using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites.Base;

public abstract class NamedEntity : Entity, InamedEntity
{
    public string Name { get; set; } = null!;
}
