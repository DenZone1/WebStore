using WebStoreDomain.Entities.Base.Interfaces;

public interface IOrdererEntity : IEntity
{
    int Order { get; set; }
}