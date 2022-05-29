using WebStoreDomain.Entities.Base.Interfaces;

public interface INamedEntitiy : IEntity
{
    string Name { get; set; }
}

