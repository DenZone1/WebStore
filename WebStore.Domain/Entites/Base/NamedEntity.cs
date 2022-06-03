using System.ComponentModel.DataAnnotations;

using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites.Base;

public abstract class NamedEntity : Entity, InamedEntity
{
    [Required]
    public string Name { get; set; } = null!;
}
