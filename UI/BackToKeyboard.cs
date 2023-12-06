using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class BackToKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("⬅️ Ortga")
            }
        });
        {
            markup.ResizeKeyboard = true;
            markup.OneTimeKeyboard = true;
        }
        return markup;
    }
}
