using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Common.Pagination
{
    public class PagedList<T>
    {
        public PagedList(int pageSize, int pageNumber, List<T> items, int totalCount)
        {
            PageSize = pageSize;
            CurrentPage = pageNumber;
            Items = items;
            TotalCount = totalCount;
        }
        public int CurrentPage {  get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Items {  get; set; }
    }
}
