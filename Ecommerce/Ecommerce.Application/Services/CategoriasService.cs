using AutoMapper;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.DTOs.Produto;
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

        public IEnumerable<CategoriaDTO> GetAllCategorias ()
        {
            var categorias = _categoriaRepository.GetAll();

            var categoriasDTOs = new List<CategoriaDTO>();

            foreach (var categoria in categorias)
            {
                categoriasDTOs.Add(_mapper.Map<CategoriaDTO>(categoria));
            }

            return categoriasDTOs;
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
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
                throw new InvalidOperationException("Categoria inexistente");

            categoria.Desativar();

            var categoriaDTO = _mapper.Map<CategoriaDTO>(_categoriaRepository.Update(categoria));

            return categoriaDTO;
        }
    }
}
