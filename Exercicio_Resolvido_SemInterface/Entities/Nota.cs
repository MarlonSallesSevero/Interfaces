using System.Globalization;
namespace Entities
{
    internal class Nota{

        public double PagBasico { get; set; }
        public double Tax { get; set; }

        public Nota(double pagBasico, double tax)
        {
            PagBasico = pagBasico;
            Tax = tax;
        }

        public double TotalPag {
            get {return PagBasico + Tax;}
        }

        public override string ToString()
        {
            return "Pagamento Basico" + PagBasico.ToString("F2", CultureInfo.InvariantCulture) +
                "\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture) +
                "\nTotal Pagamento: " + TotalPag.ToString("F2", CultureInfo.InvariantCulture);

        }
    }
}
