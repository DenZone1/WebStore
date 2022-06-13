using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels;
public class OrderViewModel
{
    [Required, MaxLength(200)]
    [Display(Name = "Ordering address")]
    public string Address { get; set; } = null!;

    [Required, MaxLength(200)]
    [Display(Name = "Phone for contact")]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = null!;

    [MaxLength(200)]
    [Display(Name = "Comment")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
}