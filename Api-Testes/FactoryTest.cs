using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Factory;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Api_Testes
{
    [TestClass]
    public class FactoryTest
    {

        [TestMethod]
        public void APIDbFactoryOnRunShouldInitializeDatabase()
        {
            APIContext db = new APIContext();
            APIDbFactory.Run();
            Assert.IsTrue(db.Database.CanConnect());
        }
        [TestMethod]
        public void APIDbFactoryOnRunShouldCreateElements()
        {
            APIContext db = new APIContext();
            APIDbFactory.Run();
            bool DataCreated = db.Registros.ToList().Count > 0 && db.Alocacao.ToList().Count > 0;
            Assert.IsTrue(DataCreated);
        }
    }
}