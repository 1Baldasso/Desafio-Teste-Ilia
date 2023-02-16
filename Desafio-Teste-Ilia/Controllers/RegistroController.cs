using Desafio_Teste_Ilia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Teste_Ilia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(ILogger<RegistroController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Registro> Get()
        {
           return Array.Empty<Registro>();
        }
    }
}