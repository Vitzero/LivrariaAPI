using Livraria.Data;
using Livraria.Dtos;
using Livraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Livraria.Controllers;

public class UserController : BaseAPI
{
    private LivroContext _context;

    public UserController(LivroContext context)
    {
        _context = context;
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]
    public IActionResult Get(int id)
    {
        Livro livro = null;
        foreach (var item in _context.Livros)
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

        foreach (var item in _context.Livros)
        {
            response.Add(new LivroResponse()
            {
                titulo = item.Titulo,
                Autor = item.Autor,
                preco = item.Preco,
                genero = item.Genero
            }

            );
        }


        return Ok(response);
    }

    [HttpPost("Livro")]
    [ProducesResponseType(typeof(LivroResponse), StatusCodes.Status200OK)]

    public IActionResult CriarLivro([FromBody] LivroRequest novoLivro)
    {
        Livro livro = new Livro()
        {
            Autor = novoLivro.Autor,
            Genero = novoLivro.genero,
            Preco = novoLivro.preco,
            Titulo = novoLivro.Titulo
        };

        _context.Livros.Add(livro);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("Livro")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromBody] LivroRequest request, int id)
    {
        var Livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        if (Livro == null)
        {
            return NotFound();
        }


        Livro.Titulo = request.Titulo;
        Livro.Autor = request.Autor;
        Livro.Genero = request.genero;
        Livro.Preco = request.preco;

        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var livro = _context.Livros.FirstOrDefault(f => f.Id == id);
        if (livro == null)
            return NotFound();

        _context.Livros.Remove(livro);

        _context.SaveChanges();
        return NoContent();
    }
}
