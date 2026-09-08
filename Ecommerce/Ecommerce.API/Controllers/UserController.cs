using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.User;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Get(
            [FromQuery] PaginationParameters paginationParameters,
            [FromQuery] string? search)
        {
            return Ok(_userService.ListUsers(paginationParameters, search));
        }

        [HttpPost]
        public ActionResult Create(UserDTO userDTO)
        {
            return Ok(_userService.CreateUser(userDTO));
        }

        [HttpPut]
        public ActionResult Update(UserDTO userDTO, int id)
        {
            return Ok(_userService.UpdateUser(userDTO, id));
        }

        [HttpDelete]
        public ActionResult<UserDTO> Delete(int id)
        {
            return Ok(_userService.DeleteUser(id));
        }
    }
}
