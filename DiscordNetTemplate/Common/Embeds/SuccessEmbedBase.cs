using Discord;
using DiscordNetTemplate.Assets;

namespace DiscordNetTemplate.Common.Embeds;

public class SuccessEmbedBase : EmbedBase
{
    public override string Name { get; } = "Succeed!";
    public override string? IconUrl { get; } = Emojis.Reactions.Check;
    public override Color Color { get; } = Colours.Success;
}