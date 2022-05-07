using Entities;
using Services;
using System;
namespace Services
{
    internal class ServicoAluguel
    {

        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        private ITaxServico _taxServ { get; set; }
        public ServicoAluguel(double pricePerHour, double pricePerDay, ITaxServico taxServico) //Injeção de controle por meio de injeção de dependencia
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxServ = taxServico;
        }
        public void ProcessPag(AluguelCarro aluguelCarro)
        {

            TimeSpan dur = aluguelCarro.Finish.Subtract(aluguelCarro.Start);

            double basicPay = 0;
            if(dur.TotalHours <= 12)
            {
                basicPay = PricePerHour * Math.Ceiling(dur.TotalHours);
            }
            else
            {
                basicPay = PricePerDay * Math.Ceiling(dur.TotalDays);
            }

            double tx = _taxServ.Tax(basicPay);

            aluguelCarro.nota = new Nota(basicPay, tx);

        }
   }
}
