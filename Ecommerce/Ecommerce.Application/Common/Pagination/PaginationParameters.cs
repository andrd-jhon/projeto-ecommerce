namespace Ecommerce.Application.Common.Pagination
{
    public class PaginationParameters
    {
        private const int DefaultPageSize = 10;
        private const int DefaultPageNumber = 1;
        private const int MaxPageSize = 50;
        private int _pageSize = DefaultPageSize;
        private int _pageNumber = DefaultPageNumber;

        public PaginationParameters(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        /// <summary>
        /// Itens que aparecerão na página solicitada.
        /// </summary>
        public int PageSize 
        { 
            get
            {
                return _pageSize;
            } 
            set
            {
                if (value <= 0)
                    _pageSize = DefaultPageSize;

                if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                
                _pageSize = value;
            } 
        }
        /// <summary>
        /// Número da página solicitada.
        /// </summary>
        public int PageNumber 
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value <= 0)
                    _pageNumber = DefaultPageNumber;
                else
                    _pageNumber = value;
            }
        }
    }
}
