using System;
using System.Globalization;
using Entities;
using Services;
namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*Enter rental data*");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm):");
            DateTime dataUp = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("PickDown (dd/MM/yyyy hh:mm):");
            DateTime dataDw = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            AluguelCarro aluguel = new AluguelCarro(dataUp, dataDw, new Veiculo(model));
            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            ServicoAluguel aluguelCarro = new ServicoAluguel(hour, day, new BrazilTaxService());//Injeção de dependencia & Inversão de Controle. *Upcasting
            aluguelCarro.ProcessPag(aluguel);
            Console.WriteLine("INVOICE:");
            Console.WriteLine(aluguel.nota);
        }
    }
}
