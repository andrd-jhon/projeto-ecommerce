using Ecommerce.Application.DTOs;
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
        public ActionResult<IEnumerable<ProdutoDTO>> Index()
        {
            return Ok(_produtosService.GetAllProdutos());
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Create (ProdutoDTO produtoDTO)
        {
            return Ok(_produtosService.CreateProduto(produtoDTO));
        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Update (ProdutoDTO produtoDTO)
        {
            try
            {
                return Ok(_produtosService.UpdateProduto(produtoDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
