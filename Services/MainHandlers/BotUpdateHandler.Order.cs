using Telegram.Bot.Types;
using EcommerseBot.UI;
using EcommerseBot.Data.Entities;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsGenerateDeliverType { get; set; } = false;
    private async Task GenerateDeliverTypeSection(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        IsGenerateDeliverType = true;
        
        var keyboard = new DeliverTypeKeyboard();
        var markup = keyboard.Generate();
        
        ArgumentNullException.ThrowIfNull(message.From);

        await client.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Buyurtmani o'zingiz olib keting, yoki Yetkazib berishni tanlang",
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }

    private async Task HandleDeliverType(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        IsGenerateDeliverType = false;
        if(message.Text is "🏃 Olib ketish")
            await GenerateDeliverByYourself(client, message, cancellationToken);

        else if(message.Text is "🚖 Yetkazib berish")
            await DeliverByCourier(client, message, cancellationToken);
    
    }

}