using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public class ProdutosService: IProdutosService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosService(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public IEnumerable<Produto> GetAllProdutos()
        {
            var teste = _produtoRepository.GetAll();
            return teste;
        }
    }
}
