using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI
{
    public class ContactKeyboard
    {
        public ReplyKeyboardMarkup  Generate()
        {
            ReplyKeyboardMarkup markup = 
                new ReplyKeyboardMarkup
                        (KeyboardButton.WithRequestContact("Contactni yuborish"));
            markup.ResizeKeyboard = true;
            markup.OneTimeKeyboard = true;

            return markup;
        }
        
    }
}