using EcommerseBot.UI;
using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task GenerateMainMenuAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var mainMenuKeyboard = new MainMenuKeyboard();
        var markup = mainMenuKeyboard.Generate();

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Juda yaxshi birgalikda buyurtma beramizmi? 😃",
            replyMarkup: markup,
            cancellationToken: cancellationToken);
    }
}
