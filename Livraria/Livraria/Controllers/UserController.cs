using Livraria.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    public class UserController : BaseAPI
    {
        [HttpGet("Livro")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var response = new LivroResponse
            {
                Autor = "Vitor",
                Id = 1,
                titulo = "Algoritmos"

            };
            return Ok(response);

        }

        [HttpPost("Livro")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]

        public IActionResult Create()
        {
            var response = new LivroRequest()
            {
                Autor = "Sei la",
                Titulo = "Sei la2"
            };

            return Ok(response);
        }

        [HttpPut("Livro")]
        [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
        public IActionResult Update([FromBody] LivroRequest request)
        {
            // Simula um "update" e retorna o resultado mockado
            var response = new LivroResponse()
            {
                Id = 1,
                titulo = request.Titulo,
                Autor = request.Autor,
                
            };

            return Ok(response);
        }


        [HttpDelete("Livro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromBody] int id)
        {
            if (id != 1)
            {
                return NotFound();
            }


            return Ok();

        }


    }
}
