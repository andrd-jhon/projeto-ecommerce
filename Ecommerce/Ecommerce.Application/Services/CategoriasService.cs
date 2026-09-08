using AutoMapper;
using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;

namespace Ecommerce.Application.Services
{
    public class CategoriasService: ICategoriasService

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriasService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public PagedList<CategoriaDTO> CarregarCategorias (PaginationParameters paginationParameters, string? search)
        {
            var query = _unitOfWork.CategoriaRepository.SearchByName(search);

            var pagedList = PagedListFactory.Create(query, paginationParameters, map: c => _mapper.Map<CategoriaDTO>(c));

            return pagedList; 
        }

        public CategoriaDTO CreateCategoria(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                throw new ArgumentException("Preencha todos os campos.");

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            categoria = _unitOfWork.CategoriaRepository.Create(categoria);

            _unitOfWork.Commit();

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO UpdateCategoria(CategoriaDTO categoriaDTO, int id)
        {
            if (categoriaDTO.Id != id)
                throw new ArgumentException("O ID informado não corresponde ao ID da categoria.");

            var categoria = _unitOfWork.CategoriaRepository.GetById(id) ?? throw new InvalidOperationException("Categoria não èncontrada.");

            categoria.AtualizarNome(categoriaDTO.Nome);

            var categoriaAtualizada = _unitOfWork.CategoriaRepository.Update(categoria);

            _unitOfWork.Commit();

            return _mapper.Map<CategoriaDTO>(categoriaAtualizada);
        }

        public CategoriaDTO DesativarCategoria(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que 0.");

            var categoria = _unitOfWork.CategoriaRepository.GetById(id)
                ?? throw new InvalidOperationException("Categoria inexistente.");
            
            categoria.Desativar();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(_unitOfWork.CategoriaRepository.Update(categoria));

            _unitOfWork.Commit();

            return categoriaDTO;
        }
    }
}
