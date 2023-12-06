using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsAskName { get; set; } = false;
    private async Task HandleNameAsync(ITelegramBotClient client, Message message,
    EcommerseBot.Data.Entities.User? user, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_userService);

        if(user is not null)
            user.Name = message.Text;

        await _userService.UpdateUserAsync(user);
        await GenerateMainMenuAsync(client, message, cancellationToken);
    }

    private async Task AskNameAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Ism sharfingizni kiriting:",
            cancellationToken: cancellationToken);
        
        IsAskName = true;
    }

    private async Task UpdateNameAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_userService);

        var user = await _userService.GetUserByIdAsync(message.From?.Id);
        
        if(user is not null)
            user.Name = message.Text;

        await _userService.UpdateUserAsync(user);
        
        await ChangeUserInfoSuccessfully(client, message, cancellationToken);

        IsAskName = false;
    }
}
