using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> Get()
        {
            try
            {
                return Ok(_produtosService.CarregarProdutos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Create (ProdutoDTO produtoDTO)
        {
            try
            {
                return Ok(_produtosService.CreateProduto(produtoDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Update (ProdutoDTO produtoDTO, int id)
        {
            try
            {
                return Ok(_produtosService.UpdateProduto(produtoDTO, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public ActionResult<ProdutoResponseDTO> Delete(ProdutoDTO produtoDTO)
        {
            try
            {
                return Ok(_produtosService.DeleteProduto(produtoDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
