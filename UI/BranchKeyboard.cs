using System.Runtime.Serialization;
using EcommerseBot.Data.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class BranchKeyboard
{
    public ReplyKeyboardMarkup  Generate()
    {
        var enumType = typeof(Branch);
        var obj = new ReadingEnumValue();

        ReplyKeyboardMarkup markup = new (new[]
        {
            new KeyboardButton[]
            {
                new KeyboardButton(obj.GetValue(enumType, Branch.AmirTemur)),
                new KeyboardButton(obj.GetValue(enumType, Branch.BuyukIpak)),
            },
            new KeyboardButton[]
            {
                new KeyboardButton(obj.GetValue(enumType, Branch.Bratvey)),
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
