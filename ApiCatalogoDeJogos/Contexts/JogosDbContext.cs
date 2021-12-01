using ApiCatalogoDeJogos.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoDeJogos.Contexts
{
    public class JogosDbContext : DbContext
    {
        public JogosDbContext(DbContextOptions<JogosDbContext> options) :base(options)
        {}

       public DbSet<Jogo> Jogos { get; set; }
    }
}
