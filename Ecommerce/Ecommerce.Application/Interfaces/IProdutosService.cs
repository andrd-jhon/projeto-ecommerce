using Ecommerce.Application.DTOs.Produto;
using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Interfaces
{
    public interface IProdutosService
    {
        IEnumerable<ProdutoResponseDTO> GetAllProdutos();
        ProdutoDTO CreateProduto(ProdutoDTO produtoDTO);
        ProdutoDTO UpdateProduto(ProdutoDTO produtoDTO);
        ProdutoDTO DeleteProduto(ProdutoDTO produtoDTO);
    }
}
