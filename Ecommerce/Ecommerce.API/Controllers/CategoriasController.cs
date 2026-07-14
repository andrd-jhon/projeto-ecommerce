using Ecommerce.Application.DTOs.Categoria;
using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Services;
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
        public ActionResult Get()
        {
            try
            {
                return Ok(_categoriasService.GetAllCategorias());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(CategoriaDTO categoriaDTO)
        {
            try
            {
                return Ok(_categoriasService.CreateCategoria(categoriaDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(CategoriaDTO categoriaDTO, int id)
        {
            try
            {
                return Ok(_categoriasService.UpdateCategoria(categoriaDTO, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<CategoriaDTO> Delete(int id)
        {
            try
            {
                return Ok(_categoriasService.DesativarCategoria(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
