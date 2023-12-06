using System.Threading;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    public bool IsSendedName { get; set; } = false;
    private async Task HandleMessageAsync(ITelegramBotClient client, Message? message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);

        var from = message.From?.FirstName;

        _logger.LogInformation($"Received message from {from}");

        var handler = message.Type switch
        {
            MessageType.Text => HandleTextMessageAsync(client, message, cancellationToken),
            MessageType.Contact => HandlePhoneNumberMessageAsync(client, message, cancellationToken),
            MessageType.Location => HandleLocationMessageAsync(client, message, cancellationToken),
            _ => HandleUnknownMessageAsync(client, message, cancellationToken)
        };
        try
        {
            await handler;
        }
        catch(Exception exception)
        {
            await HandlePollingErrorAsync(client, exception, cancellationToken);
        }
    }
    private async Task HandleUnknownMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Received message type {message.Type}");
        
        ArgumentNullException.ThrowIfNull(_userService);

        if(_userService.Exits(message.From?.Id))
        {
            var user = _userService.GetUserByIdAsync(message.From?.Id).Result;

            if(user is not null && user.Name is null)
                await AskNameAsync(client, message, cancellationToken);
            else
                await GenerateMainMenuAsync(client, message, cancellationToken);
        }
        else
        {
            await AskPhoneNumberAsync(client, message, cancellationToken);
        }
    }
}
