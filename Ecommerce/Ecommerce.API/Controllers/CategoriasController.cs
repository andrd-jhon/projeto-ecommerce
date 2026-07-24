using Ecommerce.Application.Common.Pagination;
using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasService _categoriasService;

        public CategoriasController(ICategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] PaginationParameters paginationParameters)
        {
            return Ok(_categoriasService.CarregarCategorias(paginationParameters));
        }

        [HttpPost]
        public ActionResult Create(CategoriaDTO categoriaDTO)
        {
            return Ok(_categoriasService.CreateCategoria(categoriaDTO));
        }

        [HttpPut]
        public ActionResult Update(CategoriaDTO categoriaDTO, int id)
        {
            return Ok(_categoriasService.UpdateCategoria(categoriaDTO, id));
        }

        [HttpDelete]
        public ActionResult<CategoriaDTO> Delete(int id)
        {
            return Ok(_categoriasService.DesativarCategoria(id));
        }

        [HttpGet("search")]
        public ActionResult<PagedList<CategoriaDTO>> SerachByName ([FromQuery]string searchedName,[FromQuery] PaginationParameters paginationParameters)
        {
            return _categoriasService.SearchByName(searchedName, paginationParameters);
        }
    }
}
