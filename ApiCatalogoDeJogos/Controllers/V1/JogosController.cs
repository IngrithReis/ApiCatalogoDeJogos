using ApiCatalogoDeJogos.Services;
using ApiCatalogoDeJogos.ViewModels;
using ApiCatalogoDeJogos.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace ApiCatalogoDeJogos.Controllers.V1
{
   
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase 
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        //numeração da página virá por query, 50 registros ao máximo por página.
        // notation página =1 , significa que por defalt, número da página inicia com 1
        //página = por default retorna 5
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery,Range(1,int.MaxValue)] int pagina = 1,[FromQuery,Range(1,50)] int quantidade =5)
        {
            var jogos= await _jogoService.Obter(pagina, quantidade);

            if(jogos.Count() == 0)
            {
                return NoContent();
            }
            return Ok(jogos);
        }

        [HttpGet("{idjogo:guid}")]
        // busca pela rota do id
        /// <response code="200">Retorna o jogo filtrado</response>
        /// <response code="204">Caso não haja jogo com este id</response>  
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if (jogo == null)
            {
                return NoContent();
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo(JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPut("{idjogo:guid}")]// atualização de todo o objeto
        public async Task<ActionResult> Atualizar(Guid idjogo, JogoInputModel jogo)
        {
            return Ok();
        }

        [HttpPatch("{idjogo:guid/preco/{preco:double}")]// atualiza apenas um campo 
        public async Task<ActionResult> Atualizar(Guid idjogo, double preco)
        {
            return Ok();
        }

        [HttpDelete("{idjogo:guid}")]
        public async Task<ActionResult> ApagarJogo(Guid idjogo)
        {
            return Ok();
        }


    }
}
