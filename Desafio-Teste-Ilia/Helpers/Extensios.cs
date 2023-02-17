using Desafio_Teste_Ilia.Models;

namespace Desafio_Teste_Ilia.Helpers
{
    public static class Extensios
    {
        public static TimeSpan Sum(this ICollection<Momento> time)
        {
            var array = time.ToArray();
            return (array[1] - array[0]) + (array[3] - array[2]);
        }
        public static TimeSpan Sum(this ICollection<TimeSpan> time)
        {
            TimeSpan finalTime = TimeSpan.Zero;
            foreach(var item in time)
            {
                finalTime += item;
            }
            return finalTime;
        }
    }
}
