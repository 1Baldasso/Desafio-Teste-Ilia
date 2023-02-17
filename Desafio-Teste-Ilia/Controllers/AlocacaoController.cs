using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Helpers;
using Desafio_Teste_Ilia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Teste_Ilia.Controllers
{
    [Route("v1/alocacoes")]
    [ApiController]
    public class AlocacaoController : ControllerBase
    {
        APIContext db = new APIContext();
        [HttpPost(Name ="InsereAlocacao")]
        public IActionResult Post(Helpers.AlocacaoVM alocacao)
        {
            TimeSpan horarioTotalDoDia = TimeSpan.Zero;
            try
            {
                horarioTotalDoDia = (TimeSpan)db.Registros.Include(x => x.Horarios)
                    .FirstOrDefault(x => x.Dia.Date == alocacao.Dia.Date)?.Horarios.Sum();
            }
            catch(IndexOutOfRangeException ex)
            {
                return StatusCode(400, new Mensagem { mensagem = "Você deve finalizar primeiro todos os registros do dia desejado." });
            }
            var alocacaoFinal = alocacao.Transform();
            if (alocacaoFinal.Tempo > horarioTotalDoDia)
                return StatusCode(400, new Mensagem { mensagem = "Não pode alocar tempo maior que o tempo trabalhado no dia." });
            db.Alocacao.Add(alocacaoFinal);
            db.SaveChanges();
            return Ok(alocacao);
        }
    }
}
