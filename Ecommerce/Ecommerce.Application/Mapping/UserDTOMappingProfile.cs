using AutoMapper;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.DTOs.User;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class UserDTOMappingProfile: Profile
    {
        public UserDTOMappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserDTO, User>()
            .ConstructUsing(dto =>
                new User(
                    dto.UserName,
                    dto.Email,
                    dto.PasswordHash
                ));
        }
    }
}
