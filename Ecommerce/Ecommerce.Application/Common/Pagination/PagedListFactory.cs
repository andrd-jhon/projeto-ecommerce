using System.Linq.Expressions;

namespace Ecommerce.Application.Common.Pagination
{
    public static class PagedListFactory
    {
        public static PagedList<TDto> Create<TEntity, TDto>(
        IQueryable<TEntity> query,
        PaginationParameters parameters,
        Expression<Func<TEntity, object>> orderBy,
        Func<TEntity, TDto> map)
        {
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / parameters.PageSize);
            var currentPage = Math.Min(parameters.PageNumber, totalPages == 0 ? 1 : totalPages);

            var items = query
                .OrderBy(orderBy)
                .Skip((currentPage - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList()
                .Select(map)
                .ToList();

            return new PagedList<TDto>(parameters.PageSize, items, totalCount, totalPages, currentPage);
        }
    }
}
