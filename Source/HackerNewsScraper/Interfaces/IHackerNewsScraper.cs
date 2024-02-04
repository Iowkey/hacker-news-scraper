using HackerNewsScraperAPI.Models;

namespace HackerNewsScraperAPI.Interfaces
{
    public interface IHackerNewsScraper
    {
        Task<IEnumerable<Story>> GetBestStoriesAsync(int count, CancellationToken cancellationToken);
    }
}
