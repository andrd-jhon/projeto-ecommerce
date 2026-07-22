using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Common.Pagination
{
    public class PagedList<T>
    {
        private int _currentPage;
        public PagedList(int pageSize, int currentPage, List<T> items, int totalCount, int totalPages)
        {
            PageSize = pageSize;
            Items = items;
            TotalCount = totalCount;
            TotalPages = totalPages;
            CurrentPage = currentPage;

        }
        public int CurrentPage 
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (value > TotalPages)
                    _currentPage = TotalPages;
                else if (value <= 0)
                    _currentPage = 1;
                else _currentPage = value;
            } 
        }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public IReadOnlyList<T> Items {  get; set; }
    }
}
