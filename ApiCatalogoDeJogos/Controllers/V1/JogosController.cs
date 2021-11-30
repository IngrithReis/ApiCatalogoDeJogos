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
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
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
            return Ok(jogo);
        }

        [HttpPost]
        /// <response code="200">Cao o jogo seja inserido com sucesso</response>
        /// <response code="422">Caso já exista um jogo com mesmo nome para a mesma produtora</response>  
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.InserirJogo(jogoInputModel);

                return Ok(jogo);
            }
            catch (Exception e)
            {
                return UnprocessableEntity("Já há jogo cadastrado com este nome");
            }
        }

        [HttpPut("{idjogo:guid}")]// atualização de todo o objeto

        public async Task<ActionResult> Atualizar([FromRoute] Guid idjogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idjogo, jogoInputModel);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity("Jogo não localizado");
            }

        }

        [HttpPatch("{idjogo:guid/preco/{preco:double}")]

        // Patch atualiza apenas um campo, no caso, o preço
        /// <response code="200">Cao o preço seja atualizado com sucesso</response>
        /// <response code="404">Caso não exista um jogo com este Id</response>
        public async Task<ActionResult> Atualizar([FromRoute] Guid idjogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idjogo, preco);
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity("Jogo não localizado");
            }
        }

        [HttpDelete("{idjogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idjogo)
        {
            try
            {
                await _jogoService.ApagarJogo(idjogo);
                return Ok();
            }
            catch(Exception e)
            {
                return UnprocessableEntity("Jogo não localizado");
            }
        }


    }
}
