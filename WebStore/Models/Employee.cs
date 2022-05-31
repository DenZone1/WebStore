namespace WebStore.Models;

public  class Employee
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Age { get; set; } = null!;

    public override string ToString() => $"(id:{Id} {LastName} {Name} {Patronymic} {Age})";
   

}