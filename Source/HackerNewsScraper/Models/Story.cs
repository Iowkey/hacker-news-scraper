using HackerNewsScraperAPI.Helpers;
using System.Text.Json.Serialization;

namespace HackerNewsScraperAPI.Models
{
    public class Story
    {
        [JsonPropertyName("by")]
        public string? By { get; set; }

        [JsonPropertyName("descendants")]
        public int Descendants { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("time"), JsonConverter(typeof(DateTimeOffsetCustomConverter))]
        public DateTimeOffset? Time { get; set; }

        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("kids")]
        public int[]? Kids { get; set; }
    }
}
