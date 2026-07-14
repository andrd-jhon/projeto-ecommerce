using Ecommerce.Domain.Validation;
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
        private Categoria() { }
        
        public Categoria(string nome)
        {
            DefinirNome(nome);
            DataCriacao = DateTime.UtcNow;
        }
        public string Nome { get; private set; }
        public DateTime DataCriacao {  get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public ICollection<Produto> Produtos { get; private set; } = [];

        private void ValidarNome (string nome)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(nome),
                "Nome obrigatório.");

            DomainExceptionValidation.When(
                nome.Length < 3, 
                "Nome deve ter no mínimo 3 caracteres.");
        }
        
        public void Desativar ()
        {
            if (!Ativo)
                throw new DomainExceptionValidation("A categoria já está inativa.");

            Ativo = false;
            AtualizarData();
        }

        public void Ativar ()
        {
            if (Ativo)
                throw new DomainExceptionValidation("A categoria já está ativa.");

            Ativo = true;
            AtualizarData();
        }

        private void AtualizarData ()
        {
            DataAtualizacao = DateTime.UtcNow;
        }

        private void DefinirNome (string nome)
        {
            ValidarNome(nome);
            Nome = nome;
        }

        public void AtualizarNome (string nome)
        {
            DefinirNome(nome);
            AtualizarData();
        }
    }
}
