using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        public string Preco { get; set; }
        [Required]
        public int CategoriaId { get; set; }
    }
}
