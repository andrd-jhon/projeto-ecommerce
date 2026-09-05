using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IUserService
    {
        public PagedList<UserDTO> ListUsers(PaginationParameters paginationParameters, string? search);
        UserDTO CreateUser(UserDTO userDTO);
        public UserDTO UpdateUser(UserDTO userDTO, int id);
        public UserDTO DeleteUser(int id);
    }
}
