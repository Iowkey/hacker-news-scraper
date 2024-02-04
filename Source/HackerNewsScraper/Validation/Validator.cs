namespace HackerNewsScraperAPI.Validation
{
    public static class Validator
    {
        /// <summary>
        /// Checks whether the number of stories is valid to proceed the request.
        /// </summary>
        /// <param name="count">The number of stories.</param>
        internal static void ValidateStoriesNumber(int count)
        {
            // Hacker News API allows to retrieve only 200 best stories' ids.
            if (!(count > 0 && count <= 200))
            {
                throw new ArgumentException("Number of stories should be the value between 0 at 200 included.", nameof(count));
            }
        }
    }
}
