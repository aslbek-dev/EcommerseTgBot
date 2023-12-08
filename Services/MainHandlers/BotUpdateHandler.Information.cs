using EcommerseBot.UI;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsGenerateChoosingBranch { get; set; } = false;
    private async Task GenerateChoosingBranch(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        IsGenerateChoosingBranch = true;
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            replyMarkup: ChoosingBranchMarkup(),
            text: "Qaysi shahobchani tanlaysiz?"
        );
    }
    private ReplyKeyboardMarkup ChoosingBranchMarkup()
    {
        var keyboard = new BranchKeyboard();
        var markup = keyboard.Generate();

        return markup;
    }
    private async Task HandleBranchs(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        //hozircha hammasiga bitta location and decription jonatib turamiz!!!
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Bu markazimiz 24/7 ko'rinishda o'z faoliyatini olib boradi, " +
                "Quyidagi joylashuv manzili:",
            cancellationToken: cancellationToken);
        
        IsBackToOnBranch = true;
        
        await client.SendLocationAsync(
            chatId: message.Chat.Id,
            latitude: 41.338671f,
            longitude: 69.285315f,
            replyMarkup: BackToMarkup(),
            cancellationToken: cancellationToken
        );
    }

}
