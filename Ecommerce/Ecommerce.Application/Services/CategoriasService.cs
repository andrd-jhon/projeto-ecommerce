using AutoMapper;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class CategoriasService: ICategoriasService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriasService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
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
    }
}
