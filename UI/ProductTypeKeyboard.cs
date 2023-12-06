using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot;

public class ProductTypeKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("📥 Savat"),
                new KeyboardButton("😋 Buyurtma Berish")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("Kotletlar"),
                new KeyboardButton("Baliqli taom")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("Ichimliklar"),
                new KeyboardButton("⬅️ Ortga")
            }

        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };

        return markup;
    }
}
