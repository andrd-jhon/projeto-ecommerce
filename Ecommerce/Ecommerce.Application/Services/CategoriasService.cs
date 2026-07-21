using AutoMapper;
using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System.Linq;

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

        public PagedList<CategoriaDTO> GetAllCategorias (int pageSize, int pageNumber)
        {
            //classe de parametros valida os valores vindos do front, SEMPRE devo passalos para a classe PaginationParameters.
            var parameters = new PaginationParameters(pageSize, pageNumber);

            var query = _categoriaRepository.GetAll();

            var totalCount = query.Count();


            var categorias = query
            .OrderBy(c => c.Nome)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToList();

            

            var categoriasDTOs = new List<CategoriaDTO>();

            foreach (var categoria in categorias)
            {
                categoriasDTOs.Add(_mapper.Map<CategoriaDTO>(categoria));
            }

            var pagedList = new PagedList<CategoriaDTO>(parameters.PageSize, parameters.PageNumber, categoriasDTOs, totalCount);

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
