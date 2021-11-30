using ApiCatalogoDeJogos.InputModels;
using ApiCatalogoDeJogos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Services
{
    public interface IJogoService
    {
        Task<IEnumerable<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid idJogo);
        Task<JogoViewModel> InserirJogo(JogoInputModel jogo);
        Task Atualizar(Guid idjogo, JogoInputModel jogo);
        Task Atualizar(Guid idjogo, double preco);
        Task ApagarJogo(Guid idjogo);
    }
}
