using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsAskComment { get; set; } = false;
    private async Task AskCommentAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "O'z fikr va mulohazalaringizni jo'nating 😇",
            cancellationToken: cancellationToken);
    }

    private async Task HandleCommentAsync(ITelegramBotClient client, Message message, 
        EcommerseBot.Data.Entities.User user, CancellationToken cancellationToken)
    {
        user.Comment = message.Text;

        ArgumentNullException.ThrowIfNull(_userService);
        ArgumentNullException.ThrowIfNull(message.From);
        
        await _userService.UpdateUserAsync(user);

        await client.SendTextMessageAsync(
            chatId: message.From.Id,
            text: "Fikringiz uchun tashakkur",
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken
        );

        IsAskComment = false;
        IsGenerateReactions = false;
    }
}