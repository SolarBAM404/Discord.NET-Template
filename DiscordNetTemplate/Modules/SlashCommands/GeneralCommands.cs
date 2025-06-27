using System.Reflection;
using Discord;
using Discord.Interactions;
using DiscordNetTemplate.Assets;
using DiscordNetTemplate.Common;
using DiscordNetTemplate.Common.Options;
using DiscordNetTemplate.Common.Results;
using DiscordNetTemplate.Extensions.Builders;
using Microsoft.Extensions.Options;

namespace DiscordNetTemplate.Modules.SlashCommands;

public class GeneralCommands(IOptions<ReferenceOptions> options) : ModuleBase
{
    
    [SlashCommand("ping", "Replies with Pong!")]
    public async Task PingAsync()
    {
        var embed = new EmbedBuilder()
            .WithTitle("Pong!")
            .WithDescription($"Latency: {Context.Client.Latency}ms")
            .WithColor(Colours.Primary)
            .Build();

        await RespondAsync(embed: embed);
    }
    
    [SlashCommand("about", "Shows information about the app.")]
    public async Task<RuntimeResult> AboutAsync()
    {
        var app = await Context.Client.GetApplicationInfoAsync();

        var embed = new EmbedBuilder()
            .WithTitle(app.Name)
            .WithDescription(app.Description)
            .AddField("Servers", Context.Client.Guilds.Count, true)
            .AddField("Latency", Context.Client.Latency + "ms", true)
            .AddField("Version", Assembly.GetExecutingAssembly().GetName().Version, true)
            .WithAuthor(app.Owner.Username, app.Owner.GetDisplayAvatarUrl())
            .WithFooter(string.Join(" · ", app.Tags.Select(t => '#' + t)))
            .WithColor(Colours.Primary)
            .Build();

        var components = new ComponentBuilder()
            .AddButtonLink("Support", Emojis.BrandLogos.Discord, options.Value.SupportServerUrl)
            .AddButtonLink("Source", Emojis.BrandLogos.GitHub, options.Value.SourceRepositoryUrl)
            .Build();

        await RespondAsync(embed: embed, components: components);
        return InteractionResult.Success();
    }
    
}