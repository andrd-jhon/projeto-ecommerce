using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
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
        public ActionResult<IEnumerable<Produto>> Index()
        {
            return Ok(_produtosService.GetAllProdutos());
        }
    }
}
