using EcommerseBot.UI;
using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsBackToMarkupOnSettingSection {get; set;} = false;
    private bool IsGenerateSettings { get; set; } = false;
    private bool IsAskChangingUserInfo { get; set; } = false;

    private async Task HandleSettingMessagesAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsAskChangingUserInfo = true;
        
        if(message.Text is "Ismni o'zgartirish")
            await AskChangingNameAsync(client, message, cancellationToken);
            
        else if(message.Text is "Raqamni o'zgartirish")
            await AskChangingPhoneNumberAsync(client, message, cancellationToken);

    }

    private async Task GenerateSettingSectionsAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsBackToMarkupOnSettingSection = false;

        var keyboard = new SettingKeyboard();
        var markup = keyboard.Generate();

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "⚙️ Sozlamalar",
            replyMarkup : markup,
            cancellationToken: cancellationToken);
    }
}
