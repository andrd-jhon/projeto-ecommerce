using Ecommerce.Application.Common.Pagination;
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
        public ActionResult<IEnumerable<ProdutoDTO>> Get([FromQuery]PaginationParameters paginationParameters)
        {
            return Ok(_produtosService.CarregarProdutos(paginationParameters));
        }

        [HttpPost]
        public ActionResult<ProdutoDTO> Create (ProdutoDTO produtoDTO)
        {
            return Ok(_produtosService.CreateProduto(produtoDTO));
        }

        [HttpPut]
        public ActionResult<ProdutoDTO> Update (ProdutoDTO produtoDTO, int id)
        {
            return Ok(_produtosService.UpdateProduto(produtoDTO, id));
        }

        [HttpDelete]
        public ActionResult<ProdutoResponseDTO> Delete(ProdutoDTO produtoDTO)
        { 
            return Ok(_produtosService.DeleteProduto(produtoDTO));
        }
    }
}
