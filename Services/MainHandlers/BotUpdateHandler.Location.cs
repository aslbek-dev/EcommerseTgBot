using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleLocationMessageAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        if(IsGenerateDeliverType)
            await GenerateProductTypeSection(client, message, cancellationToken);
        else
        {
            await GenerateMainMenuAsync(client, message, cancellationToken);
        }
    }
}
