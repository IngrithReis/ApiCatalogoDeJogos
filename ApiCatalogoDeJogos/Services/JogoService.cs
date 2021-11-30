using ApiCatalogoDeJogos.Entities;
using ApiCatalogoDeJogos.Exceptions;
using ApiCatalogoDeJogos.InputModels;
using ApiCatalogoDeJogos.Repositories;
using ApiCatalogoDeJogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            jogoRepository = _jogoRepository;
        }
        public async Task ApagarJogo(Guid idjogo)
        {
            var jogo = await _jogoRepository.Obter(idjogo);
            if(jogo == null)
            {
                throw new JogoNaoCadastradoException();
            }
            await _jogoRepository.Remover(idjogo);
        }

        public async Task Atualizar(Guid idjogo, JogoInputModel jogoInputViewModel)
        {
            var jogo = await _jogoRepository.Obter(idjogo);
            if(jogo == null)
            {
                throw new JogoNaoCadastradoException();

            }
            jogo.Preco = jogoInputViewModel.Preco;
            jogo.Nome = jogoInputViewModel.Nome;
            jogo.Produtora = jogoInputViewModel.Produtora;
            
            await _jogoRepository.Atualizar(jogo);
        }

        public async Task Atualizar(Guid idjogo, double preco)
        {
            var jogo = await _jogoRepository.Obter(idjogo);
            if (jogo == null)
            {
                throw new JogoNaoCadastradoException();

            }
            jogo.Preco = preco;

            await _jogoRepository.Atualizar(jogo);

        }

        public async Task<JogoViewModel> InserirJogo(JogoInputModel jogoInputViewModel)
        {

            var jogo = await _jogoRepository.Obter(jogoInputViewModel.Nome, jogoInputViewModel.Produtora);
            if(jogo.Count() > 0)
            {
                throw new JogoJaCadastradoException();
            }

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogoInputViewModel.Nome,
                Preco = jogoInputViewModel.Preco,
                Produtora = jogoInputViewModel.Produtora,
            };
            await _jogoRepository.Inserir(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogoInputViewModel.Nome,
                Preco = jogoInputViewModel.Preco,
                Produtora = jogoInputViewModel.Produtora,
            };
        }

        public async Task<List<JogoViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Obter(pagina, quantidade);
            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora,
            }).ToList();

            
        }

        public async Task<JogoViewModel> Obter(Guid idJogo)
        {   
            var jogo = await _jogoRepository.Obter(idJogo);
            if (jogo == null)
                return null;

            return new JogoViewModel{ 
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco= jogo.Preco,
                Produtora = jogo.Produtora,
            };
            
        }
        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }
    }
}
