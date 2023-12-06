using EcommerseBot.Data.Enums;

namespace EcommerseBot.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public DeliverType DeliverBy { get; set; }
    public Branch? Branch { get; set; }
    public int BasketId { get; set; }
    public Basket? Basket { get; set; }
}
