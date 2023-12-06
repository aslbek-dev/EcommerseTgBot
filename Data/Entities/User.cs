using System.Net.Mime;
namespace EcommerseBot.Data.Entities;

public class User
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string LanguageCode { get; set; } = "uz";
    public ReactionType? Reaction { get; set; }
    public string? Comment { get; set; }
    public DateTimeOffset? CreateAt { get; set; }
    public DateTimeOffset? LastInteractionAt { get; set; }
}
