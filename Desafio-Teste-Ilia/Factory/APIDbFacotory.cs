using Desafio_Teste_Ilia.Database;

namespace Desafio_Teste_Ilia.Factory
{
    public class APIDbFacotory
    {
        public static void Run()
        {
            APIContext db = new APIContext();
            db.Database.EnsureCreated();
        }
    }
}
