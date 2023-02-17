using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Testes
{
    [TestClass]
    public class RelatorioTest
    {
        APIContext db = new APIContext();
        [TestMethod]
        public void RelatorioShouldThrowExceptionWhenEmptyRegistroSet()
        {
            bool SemRegistros = db.Registros.Where(x => x.Dia == DateTime.MinValue) is not null;
            Assert.IsTrue(SemRegistros);
            Assert.ThrowsException<ArgumentException>(() => new Relatorio("0001-10"));
        }
        [TestMethod]
        public void RelatorioShouldCalculateHorasTrabalhadasWhenDatasetPopulated()
        {
            var RegistrosExistentes = db.Registros.Include(x=>x.Horarios).Where(x => x.Dia.Month == 1 && x.Dia.Year == 2023);
            Assert.IsTrue(RegistrosExistentes.Count() > 0);
            Assert.IsTrue(RegistrosExistentes.All(x => x.Horarios.Count == 4));
            Relatorio relatorio = new Relatorio("2023-01");
            Assert.IsTrue(relatorio.HorasTrabalhadas != TimeSpan.Zero);
        }
    }
}
