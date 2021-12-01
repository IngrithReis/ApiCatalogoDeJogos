using ApiCatalogoDeJogos.Contexts;
using ApiCatalogoDeJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly JogosDbContext _context;
        public JogoRepository(JogosDbContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Jogo jogo)
        {
             _context.Jogos.Update(jogo);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task Inserir(Jogo jogo)
        {
            await _context.Jogos.AddAsync(jogo);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            //return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
            return  await _context.Jogos.OrderBy(j => j.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToListAsync();
        }

        public async Task<Jogo> Obter(Guid id)
        {
            return await _context.Jogos.FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return await _context.Jogos.Where(j => j.Nome == nome && j.Produtora == produtora).ToListAsync();
        }

        public async Task Apagar(Guid id)
        {
            var jogo = await _context.Jogos.FirstOrDefaultAsync(j => j.Id == id);
           
            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
