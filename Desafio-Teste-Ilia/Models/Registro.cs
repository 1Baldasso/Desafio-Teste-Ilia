using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Teste_Ilia.Models
{
    public class Registro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public virtual List<Momento> Horarios { get; private set; } = new List<Momento>();

        public void AdicionarHorarioDeRegistro(Momento momento)
        {
            Horarios.Add(momento);
            switch(Horarios.Count())
            {
                case 3:
                    if ((momento - Horarios[1]).TotalHours < 1)
                        throw new ArgumentException("Tempo de Almoço deve ser de no mínimo 1 hora.");
                    break;
                case 4:
                    GerarTempoTotal();
                    break;
            }
        }
        private void GerarTempoTotal()
        {
            TempoTrabalhado = (Horarios[1] - Horarios[0]) + (Horarios[3]-Horarios[2]);
        }

        public TimeSpan TempoTrabalhado;
    }
}