using System.ComponentModel.DataAnnotations;

using WebStore.Domain.Entites.Base;

namespace WebStore.Domain.Entites;

public class Employee : Entity
{

    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Age { get; set; } = null!;

    public override string ToString() => $"(id:{Id} {LastName} {Name} {Patronymic} {Age})";


}