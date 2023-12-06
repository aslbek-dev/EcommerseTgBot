using System.Runtime.Serialization;
using EcommerseBot.Data.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class DeliverTypeKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        var obj = new ReadingEnumValue();

        var enumType = typeof(DeliverType);

        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(obj.GetValue(enumType, DeliverType.ByCourier)),
                new KeyboardButton(obj.GetValue(enumType, DeliverType.ByYourself)),
            },
            new KeyboardButton[]
            {
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
