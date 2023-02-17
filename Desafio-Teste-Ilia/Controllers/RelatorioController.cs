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
                relatorioFinal = db.Relatorios.FirstOrDefault(x => x.Mes == anoMes);
                if (relatorioFinal is null)
                {
                    relatorioFinal = new Relatorio(anoMes);
                    db.Relatorios.Add(relatorioFinal);
                    db.SaveChanges();
                }
            } 
            catch (Exception ex)
            {
                return StatusCode(400,new Mensagem { mensagem = ex.Message });
            }
            return Ok(relatorioFinal);
        }
    }
}
