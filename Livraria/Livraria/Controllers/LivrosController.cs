using Livraria.Data;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers;

[ApiController]
[Route("[controller]")]

public class LivrosController : ControllerBase
{
    private LivroContext _context;

    public LivrosController(LivroContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {

        var livro = _context.Livros.FirstOrDefault(l => l.Id == id);

        if (livro == null)
        {
            return NotFound();
        }

        return Ok(livro);

    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAll([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        var listaLivrosDto = _context.Livros
        .OrderBy(f => f.Id)
        .Skip(skip)
        .Take(take)
        .Select(Livro => new LivroReadDto
        {
            Titulo = Livro.Titulo,
            Genero = Livro.Genero,
            Autor = Livro.Autor,
            Preco = Livro.Preco,
        })
        .ToList();

        return Ok(listaLivrosDto);
    }

    [HttpPost("Livro")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IActionResult CriarLivro([FromBody] LivroCreateDto novoLivro)
    {
        Livro livro = new Livro()
        {
            Autor = novoLivro.Autor,
            Genero = novoLivro.Genero,
            Preco = novoLivro.Preco,
            Titulo = novoLivro.Titulo
        };

        _context.Livros.Add(livro);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("Livro")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update([FromBody] LivroCreateDto request, int id)
    {
        var Livro = _context.Livros.FirstOrDefault(l => l.Id == id);
        if (Livro == null)
        {
            return NotFound();
        }


        Livro.Titulo = request.Titulo;
        Livro.Autor = request.Autor;
        Livro.Genero = request.Genero;
        Livro.Preco = request.Preco;

        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
