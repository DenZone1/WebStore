using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites;


//[Table("ProductBrand")]

[Index(nameof(Name), IsUnique = true)]
public class Brand : NamedEntity, IOrderedEntity
{
   // [Column("BrandOrder")]
    public int Order { get; set; }

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
}

