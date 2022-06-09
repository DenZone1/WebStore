
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.Identity;

public class RegisterUserViewModel
{

    [Required(ErrorMessage = "Имя пользователя не указано")]
    [Display(Name ="Имя пользователя")]
    [MaxLength(255)]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage ="Пароль является обязательным")]



    [Required(ErrorMessage ="Не введено подтверждение пароля") ]
    [Display(Name = "Подтверждение пароля")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage ="Пароли не совпадают")]

    [MaxLength(255)]
    public string PasswordConfirm { get; set; } = null!;
}
