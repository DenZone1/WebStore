using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels.Identity;

public class LoginViewModel
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
    [Display(Name = "RememberMe?")]
    public bool RememberMe { get; set; }

    [HiddenInput]
    public string? ReturnUrl { get; set; }
}
