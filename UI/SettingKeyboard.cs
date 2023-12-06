using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class SettingKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton("Ismni o'zgartirish"),
                new KeyboardButton("Raqamni o'zgartirish")
            },
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
