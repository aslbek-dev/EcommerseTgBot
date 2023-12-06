using System.Threading;
using EcommerseBot.UI;
using Telegram.Bot.Types;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsGenerateReactions { get; set; }
    private async Task GenerateReactionSectionAsync(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsGenerateReactions = true;

        var reactionKeyboard = new ReactionKeyboard();
        var markup = reactionKeyboard.Generate();

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Bizni tanlaganingiz uchun rahmat. "+
                   "Agar siz bizning xizmat sifatimizni "+
                    "yaxshilashimizga yordam bersangiz xursand bulardik. "+
                    "Buning uchun 5 balli tizim asosida baholang",
            replyMarkup: markup,
            cancellationToken: cancellationToken);
    }
    
    private async Task HandleReactionsAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(_userService);

        var user = _userService.GetUserByIdAsync(message.From?.Id).Result;

        var reaction = message.Text switch
        {
            "Hammasi yoqdi ♥️" => ReactionType.HammasiYoqdi,
            "Yaxshi ⭐️⭐️⭐️⭐️" => ReactionType.Yaxshi,
            "Yoqmadi ⭐️⭐️⭐️" => ReactionType.Yoqmadi,
            "Yomon ⭐️⭐️" => ReactionType.Yomon,
            _ => ReactionType.Yoqmadi
        };

        if(user is not null)
        {
            user.Reaction = reaction;
            await _userService.UpdateUserAsync(user);
        }
        IsAskComment = true;
        await AskCommentAsync(client, message, cancellationToken);
    }
}
