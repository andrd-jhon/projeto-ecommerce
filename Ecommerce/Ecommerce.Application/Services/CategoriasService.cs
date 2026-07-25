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
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;

        }

        public PagedList<CategoriaDTO> CarregarCategorias (PaginationParameters paginationParameters, string? search)
        {
            var query = _categoriaRepository.SearchByName(search);

            var pagedList = PagedListFactory.Create(query, paginationParameters, orderBy: c => c.Nome, map: c => _mapper.Map<CategoriaDTO>(c));

            return pagedList;
        }

        public CategoriaDTO CreateCategoria(CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                throw new ArgumentException("Preencha todos os campos.");

            var categoria = _mapper.Map<Categoria>(categoriaDTO);

            categoria = _categoriaRepository.Create(categoria);

            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public CategoriaDTO UpdateCategoria(CategoriaDTO categoriaDTO, int id)
        {
            if (categoriaDTO.Id != id)
                throw new ArgumentException("O ID informado não corresponde ao ID da categoria.");

            var categoria = _categoriaRepository.GetById(id) ?? throw new InvalidOperationException("Categoria não èncontrada.");

            categoria.AtualizarNome(categoriaDTO.Nome);

            _mapper.Map(categoriaDTO, categoria);

            var categoriaAtualizada = _categoriaRepository.Update(categoria);

            return _mapper.Map<CategoriaDTO>(categoriaAtualizada);
        }

        public CategoriaDTO DesativarCategoria(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que 0.");

            var categoria = _categoriaRepository.GetById(id)
                ?? throw new InvalidOperationException("Categoria inexistente.");
            
            categoria.Desativar();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(_categoriaRepository.Update(categoria));

            return categoriaDTO;
        }
    }
}
