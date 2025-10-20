using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models
{
    public class LivroReadDto
    {

        public string Titulo { get; set; }
   
        public string Autor { get; set; }
     
        public string Genero { get; set; }
    
        public decimal Preco { get; set; }

        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }

}
