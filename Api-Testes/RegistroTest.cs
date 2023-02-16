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
            Registro registro = new Registro (DateTime.Parse("15/02/2023"));
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 09, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 12, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 13, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 18, 00, 00) });
            Assert.AreEqual(new TimeSpan(8, 0, 0), registro.TempoTrabalhado);
        }
        [TestMethod]
        public void RegistroShouldThrowExceptionIfLunchTimeLessThanOneHour()
        {
            Registro registro = new Registro (DateTime.Parse("15/02/2023"));
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 09, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 12, 00, 00) });
            Assert.ThrowsException<ArgumentException>(() => registro.AdicionarHorarioDeRegistro( new Momento { DataHora = new DateTime(2023, 02, 15, 12, 30, 00) }));
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 18, 00, 00) });
        }

        [TestMethod]
        public void RegistroShouldThrowExceptionIfMoreThanFourHorarios()
        {
            Registro registro = new Registro (DateTime.Parse("15/02/2023"));
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 09, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 12, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 13, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 18, 00, 00) });
            Assert.ThrowsException<InvalidOperationException>(() => registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 15, 22, 00, 00) }));
        }

        [TestMethod]
        public void RegistroShouldThrowExceptionIfDayIsWeekend()
        {
            Assert.ThrowsException<Exception>(() => new Registro((DateTime.Parse("19/02/2023"))));
        }
    }
}
