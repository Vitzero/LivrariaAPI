using Livraria.Models;

namespace Livraria.Dtos
{
    public class LivroResponse
    {
        
        public string titulo { get; set; }
        public string Autor { get; set; }

        public string genero { get; set; }

        public decimal preco { get; set; }
    }
}
