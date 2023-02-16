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
        public virtual List<Momento> Horarios { get; set; }

        public TimeSpan TempoTrabalhado;
    }
}