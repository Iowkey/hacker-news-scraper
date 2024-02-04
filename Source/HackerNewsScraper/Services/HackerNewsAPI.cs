using HackerNewsScraperAPI.Interfaces;
using HackerNewsScraperAPI.Models;
using System.Text.Json;

namespace HackerNewsScraperAPI.Services
{
    public class HackerNewsAPI : IHackerNewsAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HackerNewsAPI> _logger;

        public HackerNewsAPI(IHttpClientFactory httpClientFactory, ILogger<HackerNewsAPI> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Get story from Hacker News via API.
        /// </summary>
        /// <param name="id">Story ID.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<Story> GetStoryAsync(int id, CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://hacker-news.firebaseio.com/v0/item/{id}.json");
            using HttpClient client = _httpClientFactory.CreateClient();

            try
            {
                using var httpResponseMessage = await client.SendAsync(httpRequestMessage, cancellationToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Story>(contentStream) ?? throw new NullReferenceException();
                }
                throw new HttpRequestException(string.Format("<{MethodName}>: Failed to retrieve information about story with ID='{storyId}' from Hacker News. Http request returned with status code {StatusCode}.", nameof(GetStoryAsync), id, httpResponseMessage.StatusCode));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("<{MethodName}>: Failed to retrieve information about story with ID='{storyId}' from Hacker News. {Message}", nameof(GetStoryAsync), id, ex.Message));

                return await Task.FromException<Story>(ex);
            }
        }

        /// <summary>
        /// Get best stories' IDs from Hacker News via API
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetBestStoriesIdsAsync(CancellationToken cancellationToken)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://hacker-news.firebaseio.com/v0/beststories.json");
            using HttpClient client = _httpClientFactory.CreateClient();

            try
            {
                using var httpResponseMessage = await client.SendAsync(httpRequestMessage, cancellationToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<IEnumerable<int>>(contentStream) ?? throw new NullReferenceException();
                }
                throw new HttpRequestException(string.Format("<{MethodName}>: Failed to retrieve best stories' ids from Hacker News. Http request returned with status code {StatusCode}.", nameof(GetBestStoriesIdsAsync), httpResponseMessage.StatusCode));
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("<{MethodName}>: Failed to retrieve best stories' ids from Hacker News. {Message}", nameof(GetBestStoriesIdsAsync), ex.Message));

                return await Task.FromException<IEnumerable<int>>(ex);
            }
        }
    }
}
