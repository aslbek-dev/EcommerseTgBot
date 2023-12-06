using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class LocationKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        ReplyKeyboardMarkup markup = 
            new ReplyKeyboardMarkup
                    (KeyboardButton.WithRequestLocation("Eng yaqin filialni aniqlash"));

        markup.ResizeKeyboard = true;
        markup.OneTimeKeyboard = true;

            return markup;
    }
}
