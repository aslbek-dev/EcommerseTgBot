namespace EcommerseBot.Data.Entities;

public class Basket
{
    public int Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Product>? Products { get; set; }
}
