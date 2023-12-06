global using Telegram.Bot;
using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleEditedMessageAsync(ITelegramBotClient client, Message? message,
     CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From?.FirstName;

        _logger.LogInformation($"Received edit message from {from}: {message.Text}");

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Xabaringizni tahrirlay olmaysiz",
            replyToMessageId: message.MessageId,
            cancellationToken: cancellationToken);
    }
}
