using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Sorting;

public class SortDefinition<T>
{
    public Dictionary<string, Expression<Func<T, object>>> Fields { get; }

    public string DefaultSortBy { get; }

    public bool DefaultDescending { get; }

    public SortDefinition(
        Dictionary<string, Expression<Func<T, object>>> fields,
        string defaultSortBy,
        bool defaultDescending = false)
    {
        Fields = fields;
        DefaultSortBy = defaultSortBy;
        DefaultDescending = defaultDescending;
    }
}

