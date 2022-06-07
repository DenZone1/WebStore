using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.Identity;

public class RegisterUserViewModel
{
    [Required(ErrorMessage = "No username specified")]
    [Display(Name = "User Name")]
    [MaxLength(255)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "The password is required")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [MaxLength(255)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Password confirmation not entered")]
    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [MaxLength(255)]
    [Compare(nameof(Password), ErrorMessage = "Password and confirmation do not match")]
    public string PasswordConfirm { get; set; } = null!;
}
