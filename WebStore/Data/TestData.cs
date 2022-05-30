using WebStoreDomain.Entities.Base;
using WebStoreDomain.Entities.Base.Interfaces;
using WebStore.Domain.Entities;

using WebStore.Models;
using WebStoreDomain.Entities;

namespace WebStore.Data;

public class TestData
{
    public static ICollection<Employee> Employees { get; } =  new List<Employee>
    {
        new() {Id = 1, LastName = "Ivanov", Name ="Petr", Patronymic="Vasyl`evich", Age="57" },
        new() {Id = 2, LastName = "Petrov", Name ="Ivan", Patronymic="Sydorovisch", Age="18" },
        new() {Id = 3, LastName = "Pilat", Name ="Pontyi", Patronymic="Rimskii", Age="85" },
    };

    public static IEnumerable<Section> Sections { get; } = new Section[]
   {
          new() { Id = 01, Name = "Спорт", Order = 0 },
          new() { Id = 02, Name = "Nike", Order = 0, ParrentId = 1 },

          new() { Id = 03, Name = "Under Armour", Order = 1, ParrentId = 1 },
          new() { Id = 04, Name = "Adidas", Order = 2, ParrentId = 1 },
          new() { Id = 05, Name = "Puma", Order = 3, ParrentId = 1 },
          new() { Id = 06, Name = "ASICS", Order = 4, ParrentId = 1 },
          new() { Id = 07, Name = "Для мужчин", Order = 1 },
          new() { Id = 08, Name = "Fendi", Order = 0, ParrentId = 7 },
          new() { Id = 09, Name = "Guess", Order = 1, ParrentId = 7 },
          new() { Id = 10, Name = "Valentino", Order = 2, ParrentId = 7 },
          new() { Id = 11, Name = "Диор", Order = 3, ParrentId = 7 },
          new() { Id = 12, Name = "Версачи", Order = 4, ParrentId = 7 },
          new() { Id = 13, Name = "Армани", Order = 5, ParrentId = 7 },
          new() { Id = 14, Name = "Prada", Order = 6, ParrentId = 7 },
          new() { Id = 15, Name = "Дольче и Габбана", Order = 7, ParrentId = 7 },
          new() { Id = 16, Name = "Шанель", Order = 8, ParrentId = 7 },
          new() { Id = 17, Name = "Гуччи", Order = 9, ParrentId = 7 },
          new() { Id = 18, Name = "Для женщин", Order = 2 },
          new() { Id = 19, Name = "Fendi", Order = 0, ParrentId = 18 },
          new() { Id = 20, Name = "Guess", Order = 1, ParrentId = 18 },
          new() { Id = 21, Name = "Valentino", Order = 2, ParrentId = 18 },
          new() { Id = 22, Name = "Dior", Order = 3, ParrentId = 18 },
          new() { Id = 23, Name = "Versace", Order = 4, ParrentId = 18 },
          new() { Id = 24, Name = "Для детей", Order = 3 },
          new() { Id = 25, Name = "Мода", Order = 4 },
          new() { Id = 26, Name = "Для дома", Order = 5 },
          new() { Id = 27, Name = "Интерьер", Order = 6 },
          new() { Id = 28, Name = "Одежда", Order = 7 },
          new() { Id = 29, Name = "Сумки", Order = 8 },
          new() { Id = 30, Name = "Обувь", Order = 9 },
   };
    public static IEnumerable<Brand> Brands { get; } = new Brand[]
   {
        new() { Id = 1, Name = "Acne", Order = 0 },
        new() { Id = 2, Name = "Grune Erde", Order = 1 },
        new() { Id = 3, Name = "Albiro", Order = 2 },
        new() { Id = 4, Name = "Ronhill", Order = 3 },
        new() { Id = 5, Name = "Oddmolly", Order = 4 },
        new() { Id = 6, Name = "Boudestijn", Order = 5 },
        new() { Id = 7, Name = "Rosch creative culture", Order = 6 },
   };

   

}