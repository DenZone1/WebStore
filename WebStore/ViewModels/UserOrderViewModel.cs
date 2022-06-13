namespace WebStore.ViewModels;

public class UserOrderViewModel
{
    public int Id { get; set; }

    public DateTimeOffset Date { get; set; }

    public string Adress { get; set; }

    public string Phone { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Description { get; set; }
}