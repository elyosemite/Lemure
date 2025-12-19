using System.Text.Json;

namespace Lemure.Infrastructure.GitHubApi;

public class GitHubApiClient
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://api.github.com/search/repositories";
    private const int ItemsPerPage = 30;
    private const string UserAgent = "RepoSearchAgent";

    public GitHubApiClient(string? token = null)
    {
        _httpClient = new HttpClient();
        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async IAsyncEnumerable<T> SearchRepositoriesAsync<T>(RepoQuery query) where T : class
    {
        if (!query.HasQuery)
            throw new ArgumentException("Query must have at least one filter.", nameof(query));

        var page = 1;
        
        while (true)
        {
            var url = BuildSearchUrl(query, page);
            var response = await SendRequestAsync(url);
            
            if (!TryParseResponse<T>(response, out var items) || items.Count == 0)
                break;

            foreach (var item in items)
                yield return item;

            page++;
        }
    }

    private string BuildSearchUrl(RepoQuery query, int page)
    {
        var parameters = new List<string>
        {
            query.QueryClause,
            query.HasSortOrder ? query.SortClause : null,
            query.HasSortOrder ? query.OrderClause : null,
            $"page={page}",
            $"per_page={ItemsPerPage}"
        };

        var queryString = string.Join("&", parameters.Where(p => !string.IsNullOrEmpty(p)));
        return $"{BaseUrl}?{queryString}";
    }

    private async Task<string> SendRequestAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.UserAgent.TryParseAdd(UserAgent);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    private bool TryParseResponse<T>(string content, out List<T> items) where T : class
    {
        items = new();
        
        try
        {
            var json = JsonDocument.Parse(content);
            
            if (!json.RootElement.TryGetProperty("items", out var itemsElement))
                return false;

            foreach (var item in itemsElement.EnumerateArray())
            {
                var deserialized = JsonSerializer.Deserialize<T>(item.GetRawText());
                if (deserialized != null)
                    items.Add(deserialized);
            }

            return items.Count > 0;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}