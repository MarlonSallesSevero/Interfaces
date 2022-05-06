using System;

namespace Entities
{
    internal class AluguelCarro
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Veiculo veiculo { get; set; }
        public Nota nota { get; set; }

        public AluguelCarro(DateTime start, DateTime finish, Veiculo veiculo)
        {
            Start = start;
            Finish = finish;
            this.veiculo = veiculo;
        }
    }
}
