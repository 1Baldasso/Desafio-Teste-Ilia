using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Desafio_Teste_Ilia.Models
{
    public class Alocacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime Dia { get; set; }

        public TimeSpan Tempo { get; set; }

        public string NomeProjeto { get; set; }
    }
}
