using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Categoria: Entity
    {
        public Categoria(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }
        public string Nome { get; private set; }
        public DateTime DataCriacao {  get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public ICollection<Produto> Produtos { get; private set; } = [];
    }
}
