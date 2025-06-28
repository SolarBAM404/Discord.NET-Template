using Discord;
using DiscordNetTemplate.Assets;
using Emote = DiscordNetTemplate.Assets.Emote;

namespace DiscordNetTemplate.Common.Embeds;

public class SuccessEmbedBase : EmbedBase
{
    public override string Name { get; } = "Succeed!";
    public override string? IconUrl { get; } = Emote.Reactions.Check.Url;
    public override Color Color { get; } = Colours.Success;
}