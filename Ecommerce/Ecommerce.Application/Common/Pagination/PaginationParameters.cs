namespace Ecommerce.Application.Common.Pagination
{
    public class PaginationParameters
    {
        private const int DefaultPageSize = 5;
        private const int DefaultPageNumber = 1;
        private const int MaxPageSize = 10;
        private int _pageSize = DefaultPageSize;
        private int _pageNumber = DefaultPageNumber;

        public PaginationParameters()
        {
        }

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

                else if (value > MaxPageSize)
                    _pageSize = MaxPageSize;
                else
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
