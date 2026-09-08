using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Sorting;

public class SortingApplier : ISortingApplier
{
    public IQueryable<T> Apply<T>(
        IQueryable<T> query,
        SortingParameters parameters,
        SortDefinition<T> definition)
    {
        var sortBy = string.IsNullOrWhiteSpace(parameters.SortBy)
            ? definition.DefaultSortBy
            : parameters.SortBy;

        var sortDirection = string.IsNullOrWhiteSpace(parameters.SortDirection)
            ? (definition.DefaultDescending ? "desc" : "asc")
            : parameters.SortDirection.Trim().ToLowerInvariant();

        if (!definition.Fields.TryGetValue(sortBy!, out var expression))
        {
            throw new ArgumentException(
                $"O campo '{sortBy}' não pode ser utilizado para ordenação.");
        }

        return sortDirection switch
        {
            "asc" => query.OrderBy(expression),
            "desc" => query.OrderByDescending(expression),
            _ => throw new ArgumentException(
                $"A direção '{sortDirection}' é inválida. Utilize 'asc' ou 'desc'.")
        };
    }
}

