using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Teste_Ilia.Models
{
    public class Momento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataHora { get; set; }

        public static TimeSpan operator - (Momento a, Momento b) => a.DataHora.TimeOfDay - b.DataHora.TimeOfDay;
    }
}
