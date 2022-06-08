
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.Identity;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "enter your Name")]
    [Display(Name ="User Name")]
    [MaxLength(255)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Enter your password")]
    [Display(Name ="Password")]
    [DataType(DataType.Password)]
    [MaxLength(255)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Passwords do not match")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Passwords not Confirm")]
    [MaxLength(255)]
    public string PasswordConfirm { get; set; } = null!;
}
