using Ecommerce.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class User : Entity
    {
        private User()
        {
            
        }

        public User(string userName, string email, string passWordHash)
        {
            ValidarEntidade(userName, email, passWordHash);

            UserName = userName;
            Email = email;
            PasswordHash = passWordHash;
            DataCriacao = DateTime.Now;
        }

        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        private void ValidarEntidade (string userName, string email, string passWordHash)
        {
            ValidarNome(userName);
            ValidarEmail(email);
            ValidarPasswordHash(passWordHash);
        }

        private void ValidarNome(string nome)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(nome),
                "Nome é obrigatório.");
            DomainExceptionValidation.When(
                nome.Length < 3,
                "Nome deve ter no mínimo 3 caracteres.");
            DomainExceptionValidation.When(
                nome.Length > 250,
                "Nome deve ter no máximo 250 caracteres.");
        }

        private void ValidarEmail (string email)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(email),
                "E-mail é obrigatório.");
        }

        private void ValidarPasswordHash(string passWordHash)
        {
            DomainExceptionValidation.When(
                string.IsNullOrWhiteSpace(passWordHash),
                "PassWordHash não pode estar vazia.");
        }

        public void Atualizar(string nome, string email, string passWordHash)
        {
            ValidarEntidade(nome, email, passWordHash);
            UserName = nome;
            Email = email;
            PasswordHash = passWordHash;
            DataAtualizacao = DateTime.Now;
        }
    }
}
