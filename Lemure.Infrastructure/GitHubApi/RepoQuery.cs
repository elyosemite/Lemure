namespace Lemure.Infrastructure.GitHubApi;

public class RepoQuery
{
    private RepoSortSpecification? _sortSpecification;
    private bool _asceding = false;
    private RepoFilterSpecification[] _filters = Array.Empty<RepoFilterSpecification>();

    public RepoQuery() { }
    private RepoQuery(RepoFilterSpecification[] filters, RepoSortSpecification? sortSpecification, bool ascending) =>
        (_filters, _sortSpecification, _asceding) = (filters, sortSpecification, ascending);

    public RepoQuery Where(RepoFilterSpecification other) => new([.. _filters, other], _sortSpecification, _asceding);
    public RepoQuery SortBy(RepoSortSpecification sort) => new(_filters, sort, true);
    public RepoQuery SortByDescending(RepoSortSpecification sort) => new(_filters, sort, false);

    internal bool HasQuery => _filters.Length > 0;
    internal string QueryClause =>
        _filters.Length == 0
            ? string.Empty
            : "q=" + string.Join("+", _filters.Select(f => f.Field));

    internal bool HasSortOrder => _sortSpecification is not null;
    internal string SortClause => _sortSpecification is null
        ? string.Empty
        : $"sort={Uri.EscapeDataString(_sortSpecification.Field)}";
    internal string OrderClause => _asceding ? "order=asc" : "order=desc";
}

public class RepoFilterSpecification
{
    internal string Field { get; }
    private RepoFilterSpecification(string field) => Field = field;
    public static RepoFilterSpecification Language(string language) => new($"language:{Uri.EscapeDataString(language)}");
    public static RepoFilterSpecification Stars(int minStars) => new($"stars:>{minStars - 1}");
    public static RepoFilterSpecification NamePart(string name) => new($"{Uri.EscapeDataString(name)} in:name");
    public static RepoFilterSpecification DescriptionPart(string name) => new($"{Uri.EscapeDataString(name)} in:description");
}

public class RepoSortSpecification
{
    internal string Field { get; }
    private RepoSortSpecification(string field) => Field = field;

    public static RepoSortSpecification Stars() => new("stars");
    public static RepoSortSpecification Forks() => new("forks");
    public static RepoSortSpecification LastModified() => new("updated");
}