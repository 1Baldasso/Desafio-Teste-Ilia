using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Factory;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Api_Testes
{
    [TestClass]
    public class TesteFactory
    {
        [TestMethod]
        public void APIDbFactoryOnRunShouldInitializeDatabase()
        {
            APIContext db = new APIContext();
            APIDbFacotory.Run();
            Assert.IsTrue(db.Database.CanConnect());

        }
    }
}