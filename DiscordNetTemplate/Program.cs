using Discord.Addons.Hosting;
using DiscordNetTemplate.Common.Options;
using DiscordNetTemplate.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddEnvironmentVariables()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>(optional: true, reloadOnChange: true);

builder.Services.AddNamedOptions<BotParametersOptions>();
builder.Services.AddNamedOptions<ReferenceOptions>();

builder.Services.AddDiscordHost((config, _) =>
{
    config.SocketConfig = new Discord.WebSocket.DiscordSocketConfig
    {
        LogLevel = Discord.LogSeverity.Info,
        GatewayIntents = Discord.GatewayIntents.AllUnprivileged,
        LogGatewayIntentWarnings = false,
        UseInteractionSnowflakeDate = false,
        AlwaysDownloadUsers = false,
    };

    config.Token = builder.Configuration.GetSection(BotParametersOptions.GetSectionName()).Get<BotParametersOptions>()!.Token;
});

builder.Services.AddInteractionService((config, _) =>
{
    config.LogLevel = Discord.LogSeverity.Debug;
    config.DefaultRunMode = Discord.Interactions.RunMode.Async;
    config.UseCompiledLambda = true;
});

builder.Services.AddInteractiveService(config =>
{
    config.LogLevel = Discord.LogSeverity.Warning;
    config.DefaultTimeout = TimeSpan.FromMinutes(5);
    config.ProcessSinglePagePaginators = true;
});


IHost host = builder.Build();
await host.RunAsync();
