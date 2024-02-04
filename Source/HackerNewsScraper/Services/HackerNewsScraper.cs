using HackerNewsScraper.Models;
using HackerNewsScraperAPI.Interfaces;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace HackerNewsScraperAPI.Services
{
    public class HackerNewsScraper : IHackerNewsScraper
    {
        private readonly ILogger<HackerNewsScraper> _logger;

        public HackerNewsScraper(ILogger<HackerNewsScraper> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<Story>> GetBestStoriesAsync(int count, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
