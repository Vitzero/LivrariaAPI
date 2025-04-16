using Livraria.Models;

namespace Livraria.Dtos
{
    public class LivroRequest
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string genero { get; set; }

        public decimal preco { get; set; }

    }
}
