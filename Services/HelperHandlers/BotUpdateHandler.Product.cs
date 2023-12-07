using System.Linq;
using EcommerseBot.Data.Enums;
using EcommerseBot.UI;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler
{
    private bool IsGenerateProductType {get; set; }
    private bool IsGenerateProductByType { get; set; }
    private Message LastMessage {get; set; }

    private async Task GenerateProductTypeSection(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Nimadan boshlaymiz?",
            replyMarkup: ProductTypeMarkup(),
            cancellationToken: cancellationToken
        );

        IsGenerateProductType = true;
        IsChooseDeliverByYourself = false;
    }
    private async Task GenerateNumber(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        
        var markup = NumberKeyboard.GenerateNumberKeyboard();
        IsGenerateProductByType = true;
        
        IsBackToOnNumber = true;

        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Miqdorini tanlang yoki kiriting:",
            replyMarkup: markup,
            cancellationToken: cancellationToken
        );
    }

    private async Task HandleProductType(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsGenerateProductByType = true;
        LastMessage = message;

        IsGenerateProductType = false;
        if(message.Text is "Kotletlar")
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Taomni tanlang",
                replyMarkup: GenerateProductButtonsByProductType(ProductType.Kotletlar),
                cancellationToken: cancellationToken
            );
        }
        else if(message.Text is "Baliqli taom")
           await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Taomni tanlang",
                replyMarkup: GenerateProductButtonsByProductType(ProductType.BaliqliTaom),
                cancellationToken: cancellationToken
            );
        else if(message.Text is "Ichimliklar")
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Taomni tanlang",
                replyMarkup: GenerateProductButtonsByProductType(ProductType.Ichimliklar),
                cancellationToken: cancellationToken
            );

    }

    private async Task HandleProductName(ITelegramBotClient client, Message message, 
        CancellationToken cancellationToken)
    {
        IsGenerateProductByType = false;
        ArgumentNullException.ThrowIfNull(_productService); 

        var product =  _productService.GetProducts().FirstOrDefault(p => p.Name == message.Text);

        var text = product?.Description;

        if (text is not null)
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: text,
            cancellationToken: cancellationToken
        );
        
        await GenerateNumber(client, message, cancellationToken);
    }

    private ReplyKeyboardMarkup GenerateProductButtonsByProductType(ProductType productType)
    {
        var products = _productService?.GetProducts().Where(p => p.productType == productType);

        var buttons = products?.Select(product => new KeyboardButton(product.Name)).ToArray();

        var keyboard = new ReplyKeyboardMarkup(buttons);
        
        keyboard.ResizeKeyboard = true;

        return keyboard;
    }

    private ReplyKeyboardMarkup ProductTypeMarkup()
    {
        IsBackToOnProductType = true;
        var keyboard = new ProductTypeKeyboard();
        var markup = keyboard.Generate();

        return markup;
    }
}
