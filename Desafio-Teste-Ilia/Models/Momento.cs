using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_Teste_Ilia.Models
{
    public class Momento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime DataHora { get; set; }

        public static TimeSpan operator - (Momento a, Momento b) => a.DataHora.TimeOfDay - b.DataHora.TimeOfDay;
       
    }
}
