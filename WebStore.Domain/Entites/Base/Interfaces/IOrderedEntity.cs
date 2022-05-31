namespace WebStore.Domain.Entites.Base.Interfaces;

public interface IOrderedEntity : IEntity
{
    int Order { get; set; }
}