using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Index()
        {
            var teste = _produtoRepository.GetAll();

            return teste.ToList();
        }
    }
}
