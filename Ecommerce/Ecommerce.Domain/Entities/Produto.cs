using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.Domain.Entities.Produto;

namespace Ecommerce.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Preco { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
