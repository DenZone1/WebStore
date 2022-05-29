
namespace WebStoreDomain.Entities.Base;

public abstract class NamedEntity : Entity, INamedEntitiy
{
    public string Name { get; set; } = null!;
}