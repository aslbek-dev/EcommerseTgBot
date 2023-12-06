using System.Collections.Immutable;
using EcommerseBot.Data;
using EcommerseBot.Data.Entities;
using EcommerseBot.Services;
using EcommerseBot.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

var DbConnectionString = builder.Configuration.GetConnectionString("DbConnectionString");

builder.Services.AddDbContext<BotDbContext>(options =>
    options.UseNpgsql(DbConnectionString));

var token = builder.Configuration.GetValue("BotToken", string.Empty);

if(token is not null)
builder.Services.AddSingleton(p => new TelegramBotClient(token));

builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();

builder.Services.AddLocalization();

var app = builder.Build();

app.Run();
