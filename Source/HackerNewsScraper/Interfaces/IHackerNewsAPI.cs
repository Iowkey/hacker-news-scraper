using HackerNewsScraper.Models;

namespace HackerNewsScraperAPI.Interfaces
{
    public interface IHackerNewsAPI
    {
        Task<IEnumerable<int>> GetBestStoriesIdsAsync(CancellationToken cancellationToken);
        Task<Story> GetStoryAsync(int id, CancellationToken cancellationToken);
    }
}
