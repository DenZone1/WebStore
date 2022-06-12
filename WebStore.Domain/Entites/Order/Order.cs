
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Identity;

namespace WebStore.Domain.Entites.Order;

public class Order : Entity
{
    [Required]
    public User User { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Phone { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Adress { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

    [NotMapped]
    public decimal TotalPrice => Items.Sum(item => item.TotalItemPrice);
}

public class OrderItem : Entity
{
    [Required]
    public Product Product { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    [Required]
    public Order Order { get; set; } = null!;

    [NotMapped]
    public decimal TotalItemPrice => Price * Quantity;
}
