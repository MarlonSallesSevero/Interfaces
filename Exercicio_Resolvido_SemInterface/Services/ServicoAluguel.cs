using Entities;
using Services;
using System;
namespace Services
{
    internal class ServicoAluguel
    {

        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        public BrazilTaxService _brazilTax { get; set; } = new BrazilTaxService(); //Fortemente acoplado 
                                                                                   //Dessa maneira a classe ServicoAluguel não esta 'fechada para alteração'     
        public ServicoAluguel(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
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

            double tx = _brazilTax.tax(basicPay);

            aluguelCarro.nota = new Nota(basicPay, tx);

        }
   }
}
