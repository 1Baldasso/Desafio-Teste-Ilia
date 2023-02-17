using Desafio_Teste_Ilia.Controllers;
using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Testes
{
    [TestClass]
    public class RegistroRouteTest
    {
        APIContext db = new APIContext();
        [TestMethod]
        public async Task PostShouldCreateElementsAsync()
        {
            var contagemInicial = db.Registros.Count();
            var momento = new Momento { DataHora= DateTime.MinValue };
            RegistroController Controller = new RegistroController(null);
            await Controller.Post(momento);
            Assert.AreNotEqual(contagemInicial, db.Registros.Count());
            db.Momentos.Remove(momento);
            db.Registros.Remove(db.Registros.FirstOrDefault(x => x.Horarios.Contains(momento)));
            db.SaveChanges();
        }
    }
}
