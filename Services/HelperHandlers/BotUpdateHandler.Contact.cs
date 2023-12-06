using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleContactAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Agar sizda savollar bo'lsa bizga telefon "+
                "qilishingiz mumkin: +998 33-144-44-71",
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken);
    }
}
