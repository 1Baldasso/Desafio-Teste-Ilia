using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Factory;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Api_Testes
{
    [TestClass]
    public class FactoryTest
    {
        private APIContext db = new APIContext();

        [TestMethod]
        public void APIDbFactoryOnRunShouldInitializeDatabase()
        {
            APIDbFactory.Run();
            Assert.IsTrue(db.Database.CanConnect());
        }
        [TestMethod]
        public void APIDbFactoryOnRunShouldCreateElements()
        {
            APIDbFactory.Run();
            bool DataCreated = db.Registros.Count() > 0 && db.Alocacao.Count() > 0 && db.Relatorios.Count() > 0;
            Assert.IsTrue(DataCreated);
        }
    }
}