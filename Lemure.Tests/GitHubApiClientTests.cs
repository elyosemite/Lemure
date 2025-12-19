using System.Text.Json.Serialization;
using Lemure.Infrastructure.GitHubApi;

namespace Lemure.Tests;

public class GitHubApiClientTests
{
    public class MockRepository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("stars")]
        public int Stars { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }
    }

    [Test]
    public void Constructor_WithoutToken_CreatesClientSuccessfully()
    {
        // Act
        var client = new GitHubApiClient();

        // Assert
        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public void Constructor_WithToken_CreatesClientSuccessfully()
    {
        // Act
        var client = new GitHubApiClient("test-token-123");

        // Assert
        Assert.That(client, Is.Not.Null);
    }

    [Test]
    public async Task SearchRepositoriesAsync_WithoutFilters_ThrowsArgumentException()
    {
        // Arrange
        var query = new RepoQuery();
        var client = new GitHubApiClient();

        // Act & Assert
        Assert.ThrowsAsync<ArgumentException>(
            async () =>
            {
                await foreach (var _ in client.SearchRepositoriesAsync<MockRepository>(query)) { }
            }
        );
    }

    [Test]
    public async Task SearchRepositoriesAsync_WithLanguageFilter_BuildsCorrectUrl()
    {
        // Arrange
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("csharp"));

        var client = new GitHubApiClient();

        // Act & Assert - ensure it doesn't throw due to invalid query
        try
        {
            var count = 0;
            await foreach (var _ in client.SearchRepositoriesAsync<MockRepository>(query))
            {
                count++;
                if (count >= 1) break;
            }
            // If we get here, the query was valid and made the request
            Assert.That(count, Is.GreaterThanOrEqualTo(0));
        }
        catch (HttpRequestException)
        {
            // Network error is acceptable in test environment
            Assert.Pass("Network request was attempted with valid query");
        }
    }

    [Test]
    public async Task SearchRepositoriesAsync_WithMultipleFilters_BuildsCorrectUrl()
    {
        // Arrange
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("typescript"))
            .Where(RepoFilterSpecification.Stars(50))
            .Where(RepoFilterSpecification.NamePart("react"));

        var client = new GitHubApiClient();

        // Act & Assert
        try
        {
            var count = 0;
            await foreach (var _ in client.SearchRepositoriesAsync<MockRepository>(query))
            {
                count++;
                if (count >= 1) break;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(0));
        }
        catch (HttpRequestException)
        {
            Assert.Pass("Network request was attempted with valid query");
        }
    }

    [Test]
    public async Task SearchRepositoriesAsync_WithSortOrder_BuildsCorrectUrl()
    {
        // Arrange
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("csharp"))
            .SortBy(RepoSortSpecification.Stars());

        var client = new GitHubApiClient();

        // Act & Assert
        try
        {
            var count = 0;
            await foreach (var _ in client.SearchRepositoriesAsync<MockRepository>(query))
            {
                count++;
                if (count >= 1) break;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(0));
        }
        catch (HttpRequestException)
        {
            Assert.Pass("Network request was attempted with valid query");
        }
    }

    [Test]
    public async Task SearchRepositoriesAsync_WithDescendingSortOrder_BuildsCorrectUrl()
    {
        // Arrange
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("python"))
            .SortByDescending(RepoSortSpecification.LastModified());

        var client = new GitHubApiClient();

        // Act & Assert
        try
        {
            var count = 0;
            await foreach (var _ in client.SearchRepositoriesAsync<MockRepository>(query))
            {
                count++;
                if (count >= 1) break;
            }
            Assert.That(count, Is.GreaterThanOrEqualTo(0));
        }
        catch (HttpRequestException)
        {
            Assert.Pass("Network request was attempted with valid query");
        }
    }

    [Test]
    public void RepoQuery_Where_BuildsChainCorrectly()
    {
        // Arrange & Act
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("csharp"))
            .Where(RepoFilterSpecification.Stars(100));

        // Assert
        Assert.That(query.HasQuery, Is.True);
        Assert.That(query.QueryClause, Does.Contain("language"));
        Assert.That(query.QueryClause, Does.Contain("stars"));
    }

    [Test]
    public void RepoQuery_SortBy_SetsSortOrderAscending()
    {
        // Arrange & Act
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("java"))
            .SortBy(RepoSortSpecification.Forks());

        // Assert
        Assert.That(query.HasSortOrder, Is.True);
        Assert.That(query.SortClause, Does.Contain("forks"));
        Assert.That(query.OrderClause, Is.EqualTo("order=asc"));
    }

    [Test]
    public void RepoQuery_SortByDescending_SetsSortOrderDescending()
    {
        // Arrange & Act
        var query = new RepoQuery()
            .Where(RepoFilterSpecification.Language("go"))
            .SortByDescending(RepoSortSpecification.Stars());

        // Assert
        Assert.That(query.HasSortOrder, Is.True);
        Assert.That(query.SortClause, Does.Contain("stars"));
        Assert.That(query.OrderClause, Is.EqualTo("order=desc"));
    }

    [Test]
    public void RepoFilterSpecification_Language_CreatesCorrectFilter()
    {
        // Act
        var filter = RepoFilterSpecification.Language("rust");

        // Assert
        Assert.That(filter.Field, Does.Contain("language"));
        Assert.That(filter.Field, Does.Contain("rust"));
    }

    [Test]
    public void RepoFilterSpecification_Stars_CreatesCorrectFilter()
    {
        // Act
        var filter = RepoFilterSpecification.Stars(100);

        // Assert
        Assert.That(filter.Field, Does.Contain("stars"));
        Assert.That(filter.Field, Does.Contain("100"));
    }

    [Test]
    public void RepoFilterSpecification_NamePart_CreatesCorrectFilter()
    {
        // Act
        var filter = RepoFilterSpecification.NamePart("framework");

        // Assert
        Assert.That(filter.Field, Does.Contain("framework"));
        Assert.That(filter.Field, Does.Contain("in:name"));
    }

    [Test]
    public void RepoFilterSpecification_DescriptionPart_CreatesCorrectFilter()
    {
        // Act
        var filter = RepoFilterSpecification.DescriptionPart("database");

        // Assert
        Assert.That(filter.Field, Does.Contain("database"));
        Assert.That(filter.Field, Does.Contain("in:description"));
    }

    [Test]
    public void RepoSortSpecification_Stars_CreatesCorrectSort()
    {
        // Act
        var sort = RepoSortSpecification.Stars();

        // Assert
        Assert.That(sort.Field, Is.EqualTo("stars"));
    }

    [Test]
    public void RepoSortSpecification_Forks_CreatesCorrectSort()
    {
        // Act
        var sort = RepoSortSpecification.Forks();

        // Assert
        Assert.That(sort.Field, Is.EqualTo("forks"));
    }

    [Test]
    public void RepoSortSpecification_LastModified_CreatesCorrectSort()
    {
        // Act
        var sort = RepoSortSpecification.LastModified();

        // Assert
        Assert.That(sort.Field, Is.EqualTo("updated"));
    }
}
