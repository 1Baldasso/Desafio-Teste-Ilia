using Desafio_Teste_Ilia.Models;
using System.Globalization;

namespace Desafio_Teste_Ilia.Helpers
{
    public class AlocacaoVM
    {
        public DateTime Dia { get; set; }

        public string Tempo { get; set; }

        public string NomeProjeto { get; set; }

        public Alocacao Transform()
        {

            return new Alocacao
            {
                Dia = this.Dia.Date,
                Tempo = TransformarTimeSpan(),
                NomeProjeto = this.NomeProjeto
            };
        }

        private TimeSpan TransformarTimeSpan()
        {
            var array = Tempo.Replace("PT", "").Split('D', 'H', 'M', 'S');
            var dia = 0;
            var hora = 0;
            var minuto = 0;
            var segundo = 0;
            if (array.Length == 5)
            {
                dia = int.Parse(array[0]);
                hora = int.Parse(array[1]);
                minuto = int.Parse(array[2]);
                segundo = int.Parse(array[3]);
            }
            if (array.Length == 4)
            {
                hora = int.Parse(array[0]);
                minuto = int.Parse(array[1]);
                segundo = int.Parse(array[2]);
            }
            if (array.Length == 3)
            {
                minuto = int.Parse(array[0]);
                segundo = int.Parse(array[1]);
            }
            if (array.Length == 2)
            {
                segundo = int.Parse(array[0]);
            }
            return new TimeSpan(dia, hora, minuto, segundo);
        }
    }
}
