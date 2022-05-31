

using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewModels;

public class EmployeeViewModel : IValidatableObject
{
    [HiddenInput]
    [Display(Name = "идентификатор")]
    public int Id { get; set; }


    [Display(Name = "Фамилия")]
    [Required(ErrorMessage ="Фамилия обязательна")]
    [StringLength(12, MinimumLength = 2, ErrorMessage ="Длина от 2 до 10")]
    [RegularExpression("([А-ЯЁ][а-яЁ]+)|([A-Z][a-z]+)", ErrorMessage ="Имя должно начинаться с заглавной буквы")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Имя")]
    [Required(ErrorMessage ="Имя обязательно")]
    [StringLength(12, MinimumLength = 2, ErrorMessage = "Длина от 2 до 10")]
    public string Name { get; set; } = null!;

    [Display(Name = "Отчество")]
    [StringLength(12, ErrorMessage = "Длина до 12")]
    public string? Patronymic { get; set; } = null!;

    [Display(Name = "Возраст")]
    [Range(18,80,ErrorMessage ="от 18 до 80")]
    public string Age { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (LastName == "Asd" && Name == "Asd" && Patronymic == "Asd")
            return new[] 
            { 
                new ValidationResult("Asd - bad choice", new []
                {
                    nameof(LastName), 
                    nameof(Name),
                    nameof(Patronymic) 
                }) 
            };
        return new[]
        {
            ValidationResult.Success!,
        };
    }
}

