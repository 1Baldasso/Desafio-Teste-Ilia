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
    }
}
