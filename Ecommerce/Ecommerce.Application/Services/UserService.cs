using AutoMapper;
using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.DTOs.User;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public PagedList<UserDTO> ListUsers(PaginationParameters paginationParameters, string? search)
        {
            var query = _unitOfWork.UserRepository.SearchByName(search);

            var pagedList = PagedListFactory.Create(query, paginationParameters, orderBy: c => c.UserName, map: c => _mapper.Map<UserDTO>(c));

            return pagedList;
        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);

            user = _unitOfWork.UserRepository.Create(user);

            _unitOfWork.Commit();

            userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public UserDTO UpdateUser(UserDTO userDTO, int id)
        {
            if (userDTO.Id != id)
                throw new ArgumentException("O ID informado não corresponde ao ID do usuário.");

            var user = _unitOfWork.UserRepository.GetById(id)
                ?? throw new InvalidOperationException("Usuário não encontrado.");

            user.Atualizar(userDTO.UserName, userDTO.Email, userDTO.PasswordHash);

            var updatedUser = _unitOfWork.UserRepository.Update(user);

            _unitOfWork.Commit();

            return _mapper.Map<UserDTO>(updatedUser);
        }

        public UserDTO DeleteUser(int id)
        {
            if (id <= 0)
                return new UserDTO();

            var user = _unitOfWork.UserRepository.GetById(id);

            if (user != null)
                user.Ativo = false;

            var userDTO = _mapper.Map<UserDTO>(_unitOfWork.UserRepository.Update(user));

            _unitOfWork.Commit();

            return userDTO;
        }
    }
}
