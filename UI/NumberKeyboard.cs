using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.UI;

public class NumberKeyboard
{
    public static ReplyKeyboardMarkup GenerateNumberKeyboard()
    {

        var numbers = Enumerable.Range(1, 9).Select(num => num.ToString()).ToArray();

        var buttonsInRow = numbers.Select(num => new KeyboardButton(num)).ToArray();

        var buttons = new[] { buttonsInRow.Take(3).ToArray(), buttonsInRow.Skip(3).Take(3).ToArray(), buttonsInRow.Skip(6).ToArray() };
        
        var basketButton = new KeyboardButton("📥 Savat");
        
        var backButton = new KeyboardButton("⬅️ Ortga");

        buttons = buttons.Concat(new[] { new[] { basketButton, backButton } }).ToArray();
        var keyboard = new ReplyKeyboardMarkup(buttons);
        keyboard.OneTimeKeyboard = true;
        keyboard.ResizeKeyboard = true;

        return keyboard;
    }
}
