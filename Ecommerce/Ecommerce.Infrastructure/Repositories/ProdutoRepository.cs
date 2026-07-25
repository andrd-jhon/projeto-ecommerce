using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProdutoRepository: Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Produto> GetProdutosPorCategorias(int id)
        {
            return GetAll().Where(p => p.CategoriaId == id);
        }

        public IQueryable<Produto> SearchByName(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return GetAll();

            var normalized = search.ToLower().Trim();
            return GetAll().Where(p => p.Nome.ToLower().Contains(normalized));
        }
    }
}
