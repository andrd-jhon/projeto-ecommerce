using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
        }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
