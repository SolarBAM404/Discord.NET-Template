using Discord;

namespace DiscordNetTemplate.Common.Embeds.PageEmbeds;

public class PaginatedEmbed
{
    private List<Embed> Pages { get; set; }
    private int CurrentPage { get; set; }
    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(5);
    
    public PaginatedEmbed(List<Embed> pages)
    {
        if (pages == null || pages.Count == 0)
            throw new ArgumentException("Pages cannot be null or empty.", nameof(pages));
        
        Pages = pages;
        CurrentPage = 0;
    }
    
    public Embed GetCurrentPage()
    {
        return Pages[CurrentPage];
    }
    
    public bool NextPage()
    {
        if (CurrentPage >= Pages.Count - 1) return false;
        
        CurrentPage++;
        return true;
    }
    
    public bool PreviousPage()
    {
        if (CurrentPage <= 0) return false;
        
        CurrentPage--;
        return true;
    }
    
    public void SetPage(int pageNumber)
    {
        if (pageNumber >= 0 && pageNumber < Pages.Count)
            CurrentPage = pageNumber;
    }
    
}