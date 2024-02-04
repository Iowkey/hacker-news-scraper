using HackerNewsScraperAPI.Interfaces;

namespace HackerNewsScraperAPI.Endpoints
{
    internal static class BestStoriesEndpoint
    {
        internal static async Task<IResult> GetBestStories(IHackerNewsScraper hackerNewsScraper, int count, CancellationToken cancellationToken)
        {
            try
            {
                var stories = await hackerNewsScraper.GetBestStoriesAsync(count, cancellationToken);

                return Results.Ok(stories);
            }
            catch (Exception)
            {
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
