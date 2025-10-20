using Livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opts) : base(opts)
        {
            
        }
        public DbSet<Livro> Livros { get; set; }

    }
}
