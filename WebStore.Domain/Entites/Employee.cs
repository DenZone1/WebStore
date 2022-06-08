using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using WebStore.Domain.Entites.Base;

namespace WebStore.Domain.Entites;
 [Index(nameof(LastName), nameof(Name), nameof(Patronymic), nameof(Age), IsUnique = true)]

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