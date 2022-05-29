

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels;

public class EmployeeViewModel : IValidatableObject
{
    [HiddenInput(DisplayValue = false)]
    [Display(Name = "Идентитфикатор")]
    public int Id { get; set; }

    [Display(Name = "Фамилия")]
    [Required(ErrorMessage = "Фамилия бязательно")]//атрибут валидации(используется если свойство обязательно)
    [StringLength(10, MinimumLength = 2, ErrorMessage = "Длина от 2 до 10 символом")]
    [RegularExpression("([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат имени")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Имя бязательно")]
    [StringLength(10, MinimumLength = 2, ErrorMessage = "Длина от 2 до 10 символом")]
    public string Name { get; set; } = null!;

    [Display(Name = "Отчество")]
    [StringLength(10, ErrorMessage = "Длина до 10 символом")]
    public string Patronymic { get; set; } = null!;

    [Display(Name = "Возраст")]
    [Range(18,80,ErrorMessage ="возраст от 18 до 80")]//максимальное и минимальное значение
    public string Age { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(LastName == "Asd" && Name =="Asd" && Patronymic=="Asd")
            return new[] {new ValidationResult("Bad Choice", new[] {
                nameof(LastName),
                nameof(Name),
                nameof(Patronymic),
            }) 
            };

        return new[]
        {
            ValidationResult.Success!,
        };
    }
}

