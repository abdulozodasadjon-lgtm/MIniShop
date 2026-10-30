namespace Domain.Models;

public class Product_for_getting
{
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public decimal Price {get; set;}
    public string Category {get; set;} = null!;
}
