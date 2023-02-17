using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;

namespace Desafio_Teste_Ilia.Factory
{
    public class APIDbFactory
    {
        public static void Run()
        {
            APIContext db = new APIContext();
            db.Database.EnsureCreated();
            if (db.Registros.Count() != 0)
                return;

            Registro registro = new Registro(DateTime.Parse("16/01/2023"));
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 01, 16, 09, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 01, 16, 12, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 01, 16, 13, 00, 00) });
            registro.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 01, 16, 18, 00, 00) });
            db.Registros.Add(registro);
            Registro registro2 = new Registro(DateTime.Parse("17/02/2023"));
            registro2.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 17, 09, 00, 00) });
            registro2.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 17, 12, 00, 00) });
            registro2.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 17, 13, 00, 00) });
            registro2.AdicionarHorarioDeRegistro(new Momento { DataHora = new DateTime(2023, 02, 17, 18, 00, 00) });
            db.SaveChanges();
            db.Alocacao.Add(new Alocacao { 
                NomeProjeto = "Looney Tunes World of Mayhem",
                Dia = DateTime.Parse("16/07/2023"),
                Tempo = TimeSpan.FromHours(8),
            });
            db.SaveChanges();
        }
    }
}
