using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface ICategoriasService
    {
        PagedList<CategoriaDTO> GetAllCategorias(int pageNumber, int pageSize);
        CategoriaDTO CreateCategoria(CategoriaDTO categoriaDTO);
        CategoriaDTO UpdateCategoria(CategoriaDTO categoriaDTO, int id);
        CategoriaDTO DesativarCategoria(int id);
    }
}
