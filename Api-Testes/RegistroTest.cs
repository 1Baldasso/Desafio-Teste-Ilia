using Desafio_Teste_Ilia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Testes
{
    [TestClass]
    public class RegistroTest
    {
        [TestMethod]
        public void RegistroShouldDefineTimespanForTotalWorkedHours()
        {
            Registro registro = new Registro
            {
                Dia = DateTime.Now,
                Horarios = new List<Momento>
                {
                    new Momento { DataHora = new DateTime(2023,02,16,09,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,12,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,13,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,18,00,00) },
                }
            };
            Assert.AreEqual(new TimeSpan(8, 0, 0), registro.TempoTrabalhado);
        }
    }
}
