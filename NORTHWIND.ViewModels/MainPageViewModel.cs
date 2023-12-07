using NORTHWIND.DataAccess;
using NORTHWIND.Models;
using NORTHWIND.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWIND.ViewModels
{
    // ViewModels werden als Bindeglied (Adapter) zwischen der View und den Models
    // verwendet!
    // Ihre Aufgabe ist das *Aufbereiten* der Daten für die Anzeige
    // z.B. aus mehreren Datenquellen Daten zusammenstellen und der View weiterreichen

    // Sichtbarkeit der Klassen: internal, private, public
    // "internal" erlaubt die Verwendung dieser "MainPageViewModel"-Klasse *NUR* innerhalb dieses Projektes
    // (hier: NORTHWIND.ViewModels)

    // Die ViewModel-Klassen werden aber im User Interface Projekt benötigt, d.h. einzige mögliche Sichtbarkeit: "public"

    // Nur auf *EIGENSCHAFTEN* (properties) kann *gebunden* werden!

    // Programmierkonzept zum Aufteilen der Zuständigkeiten => N-Tier 
    // MVVM:      *Model*View*ViewModel*
    // View:      UserInterface Tier
    // ViewModel: UserInterface Tier
    // Model:     Domain Logic (Business) Tier
    public class MainPageViewModel
    {
        public List<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        // ctor
        public MainPageViewModel(ICustomersRepository repository)
        {
            // var repo = new CsvDataAccess();  // diese *Abhängigkeit* wurde entfernt!
            // man spricht von einer *dependency* 
            // diese Abhängigkeit (dependency) wurde ausgelagert in eine andere Datei

            // um diese (Repository) Komponete allerdings zu erhalten muss
            // sie in diese Code-Datei *übergeben* (injection) werden

            // => im Fachjargon spricht man von: *DEPENDENCY INJECTION*
            // d.h. wir erstellen diese Komponenten *NICHT MEHR* mittels "new"
            // sondern lassen uns diese via Parameter übergeben!

            // Der Parameter "customersRepository" ist vom Typ "ICustomersRepository"
            // also *irgendein* Objekt, welches diese Schnittstelle anbietet!

            // d.h. hier im ViewModel ist es völlig egal, ob dieses Objekt
            // vom Typ "CsvDataAccess" oder "MockDataAccess" ist!

            // Begriff: "repository" Bedeutung: *Lager* (Quelle)

            Customers = new List<Customer>();

            var data = repository.Get();
            foreach(var c in data) // das hier ist das *aufzählen*
            {
                Customers.Add(c);
            }
        }
    }
}
