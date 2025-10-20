using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O título do Livro é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O Nome do Autor é obrigatório!")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "O título do Genero é obrigatório!")]
        public string Genero { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Digite um preço válido!")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Preco { get; set; }
    }

}
