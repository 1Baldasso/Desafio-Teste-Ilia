namespace Desafio_Teste_Ilia.Models
{
    public class Alocacao
    {
        public DateTime Dia { get; set; }

        public TimeSpan Tempo { get; set; }

        public Projeto Projeto { get; set; }
    }
}
