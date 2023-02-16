namespace Desafio_Teste_Ilia.Models
{
    public class Relatorio
    {
        public string Mes { get; set; }
        public TimeSpan HorasTrabalhadas { get; set; }
        public TimeSpan HorasExcedentes { get; set; }
        public TimeSpan HorasDevidas { get; set; }
        public List<Registro> Registros { get; set; }

        public List<Alocacao> Alocacoes { get; set; }
    }
}
