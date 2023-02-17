using Desafio_Teste_Ilia.Database;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Teste_Ilia.Models
{
    public class Relatorio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Mes { get; set; }
        public TimeSpan HorasTrabalhadas { get; set; }
        public TimeSpan HorasExcedentes { get; set; }
        public TimeSpan HorasDevidas { get; set; }
        public virtual List<Registro> Registros { get; set; }
        public virtual List<Alocacao> Alocacoes { get; set; }

        public Relatorio() { }
        public Relatorio(string anoMes)
        {
            APIContext db = new APIContext();
            this.Mes = anoMes;
            var mes = int.Parse(anoMes.Substring(5, 2));
            var ano = int.Parse(anoMes.Substring(0, 4));
            this.Registros = db.Registros.AsNoTracking().Include(x => x.Horarios).Where(x => x.Dia.Month == mes && x.Dia.Year == ano)
                .ToList();
            this.Alocacoes = db.Alocacao.Where(x => x.Dia.Month == mes && x.Dia.Year == ano)
                .ToList();
            CalcularTempoDeTrabalho();
            CalcularHorasExcedentes(TimeSpan.FromHours(160));
            CalcularHorasExcedentes(TimeSpan.FromHours(160));
        }
        private void CalcularTempoDeTrabalho()
        {
            foreach (var registro in Registros)
            {
                var horarioPreAlmoco = (registro.Horarios[1].DataHora - registro.Horarios[0].DataHora);
                var horarioPosAlmoco = (registro.Horarios[3].DataHora - registro.Horarios[2].DataHora);
                HorasTrabalhadas += (horarioPreAlmoco + horarioPosAlmoco);
            }
        }
        private void CalcularHorasExcedentes(TimeSpan HorasPrevistas)
        {
            var diferenca = HorasTrabalhadas - HorasPrevistas;
            var HorasTimeSpan = diferenca > TimeSpan.Zero ? diferenca : TimeSpan.Zero;
            HorasExcedentes = HorasTimeSpan;
        }
        private void CalcularHorasDevidas(TimeSpan HorasPrevistas)
        {
            var diferenca = HorasPrevistas - HorasTrabalhadas;
            HorasDevidas = diferenca > TimeSpan.Zero ? diferenca : TimeSpan.Zero;
        }
    }
}
