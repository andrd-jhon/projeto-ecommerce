using System.ComponentModel.DataAnnotations;


namespace Ecommerce.Application.DTOs.Categoria
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
