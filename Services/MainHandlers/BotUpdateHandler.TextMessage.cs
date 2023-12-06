using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    public async Task HandleTextMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message.From);
        ArgumentNullException.ThrowIfNull(_userService);

        var from = message.From;

        _logger.LogInformation($"From: {from.FirstName}");

        bool IsUserExits = _userService.Exits(from.Id);

        if(!IsUserExits)
        {
            await AskPhoneNumberAsync(client, message, cancellationToken);
        }

        else if(IsUserExits)
        {
            var user = _userService.GetUserByIdAsync(from.Id).Result;

            if(user?.Name is null)
            {
                await HandleNameAsync(client, message, user, cancellationToken);
            }
            else if(message.Text is "/start")
                await GenerateMainMenuAsync(client, message, cancellationToken);
            
            else if(message.Text is "⬅️ Ortga")
                await HandleBackToMessageAsync(client, message, cancellationToken);

            else if (message.Text is "✍️ Fikr bildirish")
                await GenerateReactionSectionAsync(client, message, cancellationToken);
            
            else if (IsGenerateReactions && !IsAskComment)
                await HandleReactionsAsync(client, message,cancellationToken);

            else if (IsGenerateReactions && IsAskComment)
                await HandleCommentAsync(client, message, user, cancellationToken);
            
            else if(message.Text is "☎️ Biz bilan aloqa")
                await HandleContactAsync(client, message,cancellationToken);

            else if(message.Text is "ℹ️ Ma'lumot")
                await GenerateChoosingBranch(client, message, cancellationToken);
                
            else if(IsGenerateChoosingBranch)
                await HandleBranchs(client, message, cancellationToken);

            else if(message.Text is "⚙️ Sozlamalar")
                await GenerateSettingSectionsAsync(client, message, cancellationToken);

            else if(message.Text is "Ismni o'zgartirish" or "Raqamni o'zgartirish" or "🇺🇿 Tilini tanlang")
                await HandleSettingMessagesAsync(client, message, cancellationToken);
            
            else if(IsAskChangingUserInfo)
                await HandleChangingUserInfoAsync(client, message, cancellationToken);
            
            else if(message.Text is "🛍 Buyurtma berish")
                await GenerateDeliverTypeSection(client, message, cancellationToken);

            else if(IsGenerateDeliverType)
                await HandleDeliverType(client, message, cancellationToken);

            else if(IsChooseDeliverByYourself)
                await GenerateProductTypeSection(client, message, cancellationToken);
            
            else if(IsGenerateProductType)
                await HandleProductType(client, message, cancellationToken);
            
            else if(IsGenerateProductByType)
                await HandleProductName(client, message, cancellationToken);

        }
    }
}
