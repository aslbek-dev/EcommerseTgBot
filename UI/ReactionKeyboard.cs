using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class ReactionKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("Hammasi yoqdi ♥️")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("Yaxshi ⭐️⭐️⭐️⭐️")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("Yoqmadi ⭐️⭐️⭐️")
            },
            new KeyboardButton[]
            {
                new KeyboardButton("Yomon ⭐️⭐️")
            }
        })
        {
            ResizeKeyboard = true,
            OneTimeKeyboard = true
        };

        return markup;
    }
}
