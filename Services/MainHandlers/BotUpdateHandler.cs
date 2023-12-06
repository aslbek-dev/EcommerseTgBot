using EcommerseBot.Data.Entities;
using EcommerseBot.Data.Enums;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EcommerseBot.Services.Handlers;

public partial class BotUpdateHandler : IUpdateHandler
{
    public readonly ILogger<BotUpdateHandler> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private UserService? _userService;
    private ProductService? _productService;

    public BotUpdateHandler(ILogger<BotUpdateHandler> logger,
                            IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }
    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Error occured with Telegram Bot: {exception.Message}");

        return Task.CompletedTask;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        _userService = scope.ServiceProvider.GetRequiredService<UserService>();
        _productService = scope.ServiceProvider.GetRequiredService<ProductService>();

    //    await _productService.Add();
    //    _logger.LogInformation("qoshildi");

        var handler = update.Type switch
        {
            UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
            UpdateType.EditedMessage => HandleEditedMessageAsync(botClient, update.EditedMessage, cancellationToken),
            //Handle other updates
            _ => HandleUnknownUpdateAsync(botClient, update, cancellationToken)
        };

        try
        {
            await handler;
        }
        catch(Exception exception)
        {
            await HandlePollingErrorAsync(botClient, exception, cancellationToken);
        }
    }

    private Task HandleUnknownUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Update type {update.Type} is received");

        return Task.CompletedTask;
    }
}
    
