using EcommerseBot.Data.Enums;

namespace EcommerseBot.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public float Volume { get; set; }
    public decimal Price { get; set; }
    public int? PhotoId { get; set; }
    public Photo? Photo { get; set; }
    public ProductType productType { get; set; }
}
