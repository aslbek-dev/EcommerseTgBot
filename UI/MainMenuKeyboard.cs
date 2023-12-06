using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class MainMenuKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("🛍 Buyurtma berish")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("✍️ Fikr bildirish"),
                new KeyboardButton("☎️ Biz bilan aloqa")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("ℹ️ Ma'lumot"),
                new KeyboardButton("⚙️ Sozlamalar")
            }
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };

        return markup;
    }
}
