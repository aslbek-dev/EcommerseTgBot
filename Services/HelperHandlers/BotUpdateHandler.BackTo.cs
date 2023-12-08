using EcommerseBot.UI;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsBackToOnLocationAndBranchMarkup {get; set;} = false;
    private bool IsBackToOnProductType { get; set; } = false;
    private bool IsBackToOnNumber { get; set; } = false;
    private async Task HandleBackToMessageAsync(ITelegramBotClient client, Message message,
        CancellationToken cancellationToken)
    {
        if(IsBackToMarkupOnSettingSection)
        {   await GenerateSettingSectionsAsync(client, message, cancellationToken);
                IsAskChangingPhoneNumber = false;
        }
         else if(IsBackToOnNumber)
        {
            IsBackToOnNumber = false; 
            await HandleProductType(client, LastMessage, cancellationToken);
        }
            
        else if(IsBackToMarkupOnBranch )
        {
            IsBackToMarkupOnBranch = false;
            await GenerateChoosingBranch(client, message, cancellationToken);
        }
        
        else if(IsBackToOnLocationAndBranchMarkup)
        {
            IsBackToOnLocationAndBranchMarkup = false;
            await GenerateDeliverTypeSection(client, message, cancellationToken);
        }
        else if(IsBackToOnProductType)
        {
            IsBackToOnProductType = false;
            await GenerateDeliverByYourself(client, message, cancellationToken);
        }
        else if(IsGenerateChoosingBranch)
        {
            IsGenerateChoosingBranch = false;
            await GenerateMainMenuAsync(client, message, cancellationToken);
        }
        else
            await GenerateMainMenuAsync(client, message, cancellationToken);
    }
    private ReplyKeyboardMarkup BackToMarkup()
    {
        var backToKeyboard = new BackToKeyboard();
        var markup = backToKeyboard.Generate();
        return markup;
    }
}
