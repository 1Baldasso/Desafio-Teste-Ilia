using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_Teste_Ilia.Models
{
    public class Alocacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Dia { get; set; }

        public TimeSpan Tempo { get; set; }

        public virtual Projeto Projeto { get; set; }
    }
}
