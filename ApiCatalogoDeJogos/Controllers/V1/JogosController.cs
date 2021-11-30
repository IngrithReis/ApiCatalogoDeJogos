using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogoDeJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase 
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }

        [HttpGet("{idjogo:guid}")]
        public async Task<ActionResult<object>> Obter(Guid idJogo )
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InserirJogo(object jogo)
        {
            return Ok();
        }

        [HttpPut("{idjogo:guid}")]
        public async Task<ActionResult> Atualizar(Guid idjogo, object jogo)
        {
            return Ok();
        }

        [HttpPatch("{idjogo:guid/preco/{preco:double}")]
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
