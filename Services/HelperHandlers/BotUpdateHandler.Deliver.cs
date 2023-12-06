using EcommerseBot.UI;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsChooseDeliverByYourself { get; set; } = false;
    private async Task GenerateDeliverByYourself(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Siz qayerda joylashgansiz 👀? " +
                "Agar lokatsiyangizni jo'natsangiz 📍, "+
                "sizga yaqin bo'lgan filialni aniqlaymiz",
            replyMarkup: BranchAndLocationMarkup(),
            cancellationToken: cancellationToken
        );

        IsChooseDeliverByYourself = true;
    }
    private async Task DeliverByCourier(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Buyurtmangizni qayerga yetkazib berish kerak 🚙?",
            replyMarkup: LocationMarkup(),
            cancellationToken: cancellationToken
        );
    }
    private ReplyKeyboardMarkup BranchAndLocationMarkup()
    {
        IsBackToOnLocationAndBranchMarkup = true;

        var keyboard = new BranchsAndLocation();
        var markup = keyboard.Generate();

        return markup;
    }
    private ReplyKeyboardMarkup LocationMarkup()
    {
        var keyboard = new LocationKeyboard();
        var markup = keyboard.Generate();

        return markup;
    }
}
