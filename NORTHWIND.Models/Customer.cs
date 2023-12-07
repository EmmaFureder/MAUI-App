using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWIND.Models
{
    // Modell-Klassen *beschreiben* die zu bearbeitenden Daten
    // POCO-Klassen: plain old CLR (common language runtime) Object
    // CLR-Objekte sind: string, int, double ... und auf allen Plattformen verfügbar
    // eine Modell-Klasse ist eine *Abbildung* der realen Welt!!!
    public class Customer
    {
        public string ID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }
    }
}
