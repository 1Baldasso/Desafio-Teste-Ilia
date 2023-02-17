using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Teste_Ilia.Controllers
{
    [Route("v1/folha-de-ponto/{anoMes}")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        APIContext db = new APIContext();
        [HttpGet]
        public IActionResult Get(string anoMes)
        {
            var relatorioFinal = new Relatorio();
            try
            {
                relatorioFinal = new Relatorio(anoMes);
            } 
            catch (Exception ex)
            {
                return StatusCode(400,new Mensagem { mensagem = ex.Message });
            }
            return Ok(relatorioFinal);
        }
    }
}
