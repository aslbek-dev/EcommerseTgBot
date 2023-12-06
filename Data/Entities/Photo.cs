namespace EcommerseBot.Data.Entities;

public class Photo
{
    public int Id { get; set; }  
    public byte[]? Bytes { get; set; }  
    public string? Description { get; set; }  
    public string FileExtension { get; set; } = "jpg";
    public decimal Size { get; set; }     
    public Product? Product { get; set; }
}
