using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Desafio_Teste_Ilia.Controllers
{
    [ApiController]
    [Route("v1/batidas")]
    public class RegistroController : ControllerBase
    {
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(ILogger<RegistroController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "InsereBatida")]
        public async Task<IActionResult> Post(Momento momento)
        {
            var registroManipulado = new Registro(DateTime.Today);
            try
            {
                APIContext db = new APIContext();
                var registro_existente = db.Registros.Include(x=>x.Horarios).FirstOrDefault(x => x.Dia.Date == momento.DataHora.Date);
                if (registro_existente is null)
                {
                    registro_existente = new Registro(momento.DataHora.Date);
                    db.Registros.Add(registro_existente);
                }
                registro_existente.AdicionarHorarioDeRegistro(momento);
                registroManipulado = registro_existente;
                db.SaveChanges();
            }
            catch (FormatException ex)
            {
                return StatusCode(400, new Mensagem { mensagem = "Data e hora em formato inválido" }); 
            }
            catch (Exception ex)
            {   
                
                return StatusCode(403,new Mensagem { mensagem = ex.Message } );
            }
            return Created("",registroManipulado);
        }
    }
}