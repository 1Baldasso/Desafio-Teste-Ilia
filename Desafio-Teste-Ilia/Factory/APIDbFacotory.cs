using Desafio_Teste_Ilia.Database;
using Desafio_Teste_Ilia.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

namespace Desafio_Teste_Ilia.Factory
{
    public class APIDbFacotory
    {
        public static void Run()
        {
            APIContext db = new APIContext();
            db.Database.EnsureCreated();
            db.Registros.Add(new Registro
            {
                Dia = DateTime.Parse("15/02/2023"),
                Horarios = new List<Momento>
                { 
                    new Momento { DataHora = new DateTime(2023,02,15,09,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,15,12,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,15,13,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,15,18,00,00) },
                }
            });
            db.Registros.Add(new Registro
            {
                Dia = DateTime.Parse("16/02/2023"),
                Horarios = new List<Momento>
                {
                    new Momento { DataHora = new DateTime(2023,02,16,09,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,12,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,13,00,00) },
                    new Momento { DataHora = new DateTime(2023,02,16,18,00,00) },
                }
            });
            db.Projetos.Add(new Projeto { Nome = "Looney Tunes WOM" });
            db.Alocacao.Add(new Alocacao { 
                Projeto = db.Projetos.First(),
                Dia = DateTime.Parse("15/02/2023"),
                Tempo = db.Registros.Last().Horarios.First().DataHora.TimeOfDay - db.Registros.First().Horarios.First().DataHora.TimeOfDay - new TimeSpan(1,0,0),
            });
            db.Relatorios.Add(new Relatorio
            {
                Alocacoes = db.Alocacao.Where(x => x.Dia.Month == 2).ToList(),
                Mes = $"{2}/{2023}",
                HorasTrabalhadas = db.Registros
                    .Where(x => x.Dia.Month == 2).Select(x=>x.TempoTrabalhado).First(),

            });
        }
    }
}
