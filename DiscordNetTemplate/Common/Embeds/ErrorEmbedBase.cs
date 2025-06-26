using Discord;
using DiscordNetTemplate.Assets;

namespace DiscordNetTemplate.Common.Embeds;

public class ErrorEmbedBase : EmbedBase
{
    public override string Name { get; } = "Error";
    public override string? IconUrl { get; } = Emojis.Reactions.Cross;
    public override Color Color { get; } = Colours.Error;
}