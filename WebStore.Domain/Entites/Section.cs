using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using WebStore.Domain.Entites.Base.Interfaces;
using WebStore.Domain.Entites.Base;

namespace WebStore.Domain.Entites;

[Index(nameof(Name), IsUnique = false)]
public class Section : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public int? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public Section? Parent { get; set; } //навигационное свойство EntityFramework

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}