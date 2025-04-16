using Livraria.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;
namespace Livraria.Controllers
{
    public class UserController : BaseAPI
    {
        private static List<Livro> livros = new List<Livro>();
        private static int ultimoId = 0;



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            Livro livro = null;
            foreach (var item in livros)
            {
                if (item.Id == id)
                {
                    livro = item;
                    break;
                }
            }

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);

        }

        [HttpGet("Livros")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var response = new List<LivroResponse>();

            foreach (var item in livros)
            {
                response.Add(new LivroResponse()
                    {
                        titulo = item.Nome,
                        Autor = item.Autor,
                        preco = item.Preco,
                        genero = item.genero
                    }
                
                );
            }


            return Ok(response);
        }

        [HttpPost("Livro")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]

        public IActionResult CriarLivro([FromBody] Livro novoLivro)
        {
            novoLivro.Id = ++ultimoId;

            livros.Add(novoLivro);

            return Ok();
        }

        [HttpPut("Livro")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] LivroRequest request, int id)
        {
;           
            foreach (var item in livros)
            {
                if (item.Id == id)
                {
                    item.Nome = request.Titulo;
                    item.Autor = request.Autor;
                    item.genero = request.genero;
                    item.Preco = request.preco;

                    var response = new LivroResponse()
                    {
                        titulo = item.Nome,
                        Autor = item.Autor,
                        genero = item.genero,
                        preco = item.Preco
                    };

                    return Ok(response);


                }
            }


            return NotFound();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var livro = livros.Find(l => l.Id == id);
            if (livro == null)
                return NotFound();

            livros.Remove(livro);
            return NoContent();

        }


    }
}
