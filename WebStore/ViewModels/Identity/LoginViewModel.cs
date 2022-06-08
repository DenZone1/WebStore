using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels.Identity;

public class LoginViewModel
{
    [Required(ErrorMessage = "enter your Name")]
    [Display(Name = "User Name")]
    [MaxLength(255)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Enter your password")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [MaxLength(255)]
    public string Password { get; set; } = null!;

    [Display(Name ="Remember?")]
    public bool RememberMe { get; set; }

    [HiddenInput(DisplayValue = false)]
    public string? ReturnUrl { get; set; }
}
