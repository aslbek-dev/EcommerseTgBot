using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleChangingUserInfoAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        if(message.Text is not null)
        {
            if(IsValidPhoneNumber(message.Text))
                await UpdatePhoneNumberAsync(client, message, cancellationToken);

            else if(!IsValidPhoneNumber(message.Text) && IsAskChangingPhoneNumber)
                await AskChangingPhoneNumberAsync(client, message, cancellationToken);
            
            else
                await UpdateNameAsync(client, message, cancellationToken);
        }
            
    }

    private async Task AskChangingPhoneNumberAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        var text = "📱 Raqamni +998********* shakilda yuboring.";

        if(message.Text is not null)
            if(!IsValidPhoneNumber(message.Text) && IsAskChangingPhoneNumber)
                text = "Xato format!" + text;

        IsBackToMarkupOnSettingSection = true;

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: text,
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken);

        IsAskChangingPhoneNumber = true;   
    }
    

    private async Task AskChangingNameAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsBackToMarkupOnSettingSection = true;

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Ism sharfingizni kiriting:",
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken);
    }

    private async Task ChangeUserInfoSuccessfully(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsBackToMarkupOnSettingSection = true; 

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "✅✅✅",
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken);
        
        IsAskChangingUserInfo = false;
    }
}
