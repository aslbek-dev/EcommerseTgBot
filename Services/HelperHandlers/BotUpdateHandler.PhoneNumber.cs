using System.Text.RegularExpressions;
using EcommerseBot.UI;
using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsAskChangingPhoneNumber { get; set; } = false;
    
    private async Task AskPhoneNumberAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var contactKeyboard = new ContactKeyboard();
        var markup = contactKeyboard.Generate();

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Assalomu Aleykum, bot'ning imkoniyatlaridan "+
            "foydalanishingiz uchun kontaktingizni yuboring!",
            replyMarkup: markup,
            cancellationToken: cancellationToken);
    }

    private async Task HandlePhoneNumberMessageAsync(ITelegramBotClient client, Message message,
         CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Received message type {message.Type}");
        
        ArgumentNullException.ThrowIfNull(message.From);
        ArgumentNullException.ThrowIfNull(message.Contact);
        ArgumentNullException.ThrowIfNull(_userService);

        if(!_userService.Exits(message.From.Id))
        {
            var newUser = new EcommerseBot.Data.Entities.User()
            {
                Id = message.From.Id,
                ChatId = message.Chat.Id,
                PhoneNumber = message.Contact.PhoneNumber
            };

            await _userService.AddUserAsync(newUser);

            await AskNameAsync(client, message, cancellationToken);
        }
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        string pattern = @"^\+998\d{9}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }
    

    private async Task UpdatePhoneNumberAsync(ITelegramBotClient client, Message message,
         CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_userService);

        var user = await _userService.GetUserByIdAsync(message.From?.Id);

        if(user is not null)
            user.PhoneNumber = message.Text;

        await _userService.UpdateUserAsync(user);

        await ChangeUserInfoSuccessfully(client, message, cancellationToken);
        
        IsAskChangingPhoneNumber = false;
    }
}
