using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class CategoriaDTO
    {
        public CategoriaDTO(string nome)
        {
            this.Nome = nome;
        }
        public int CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public ICollection<Produto> Produtos { get; private set; } = [];
    }
}
