using Discord;

namespace DiscordNetTemplate.Extensions.Builders;

public static class ComponentBuilderExtensions
{
    
    public static ComponentBuilder AddButtonLink(
        this ComponentBuilder builderExtensions, 
        string label, 
        string url, 
        Emote emote,
        ButtonStyle style = ButtonStyle.Link)
    {
        ButtonBuilder button = new ButtonBuilder()
            .WithLabel(label)
            .WithStyle(ButtonStyle.Link)
            .WithUrl(url)
            .WithEmote(emote);
;
        return builderExtensions.WithButton(button);

    }
    
}