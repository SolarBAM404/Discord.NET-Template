using Discord;
using DiscordNetTemplate.Assets;
using Emote = DiscordNetTemplate.Assets.Emote;

namespace DiscordNetTemplate.Common.Embeds;

public class ErrorEmbedBase : EmbedBase
{
    
    public static ErrorEmbedBase Instance { get; } = new();
    
    public override string Name { get; } = "Error";
    public override string? IconUrl { get; } = Emote.Reactions.Cross.Url;
    public override Color Color { get; } = Colours.Error;
}