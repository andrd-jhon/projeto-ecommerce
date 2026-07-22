using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Common.Pagination
{
    public class PagedList<T>(int pageSize, List<T> items, int totalCount, int totalPages, int currentPage)
    {
        public int CurrentPage { get; } = currentPage;
        public int PageSize { get; } = pageSize;
        public int TotalCount { get; } = totalCount;
        public int TotalPages { get; } = totalPages;
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IReadOnlyList<T> Items { get; } = items;
    }
}
