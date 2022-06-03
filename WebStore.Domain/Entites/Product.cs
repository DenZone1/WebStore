using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites;

[Index(nameof(Name), IsUnique = false)]
public class Product : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int SectionId { get; set; }

    [ForeignKey(nameof(SectionId))]
    [Required]
    public Section Section { get; set; } = null!;


    public int? BrandId { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Column(TypeName ="decimal(18,2)")]
    public decimal Price { get; set; }
}
