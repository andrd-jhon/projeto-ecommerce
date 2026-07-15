using Ecommerce.Domain.Validation;
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
    public class Produto : Entity
    {
        private Produto()
        { 
        }
        public Produto(string nome, decimal preco, int categoriaId)
        {
            DefinirEntidade(nome, preco, categoriaId);
        }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public Categoria Categoria { get; private set; }
        public int CategoriaId { get; private set; }

        private void ValidarEntidade (string nome, decimal preco, int categoriaId)
        {
            ValidarNome(nome);
            ValidarPreco(preco);
            ValidarCategoriaId(categoriaId);
        }

        private void DefinirEntidade(string nome, decimal preco, int categoriaId)
        {
            ValidarEntidade(nome, preco, categoriaId);
            Nome = nome;
            Preco = Math.Round(preco, 2);
            CategoriaId = categoriaId;
            DataCriacao = DateTime.Now;
        }

        private void AtualizarEntidade(string nome, decimal preco, int categoriaId, DateTime dataCriacao)
        {
            ValidarEntidade(nome, preco, categoriaId);
            Nome = nome;
            Preco = Math.Round(preco, 2);
            CategoriaId = categoriaId;
            DataCriacao = dataCriacao;
            DataAtualizacao = DateTime.UtcNow;
        }

        private void ValidarNome(string nome)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(nome),
                "Nome é obrigatório.");
            DomainExceptionValidation.When(
                nome.Length < 3,
                "Nome deve ter no mínimo 3 caracteres.");
        }

        private void ValidarPreco (decimal preco)
        {
            DomainExceptionValidation.When(
                preco <= 0,
                "Preço inválido. Deve ser maior que 0.");
        }

        private void ValidarCategoriaId (int categoriaId)
        {
            DomainExceptionValidation.When(
                categoriaId < 0,
                "ID de categoria inválido.");
        }
    }
}
