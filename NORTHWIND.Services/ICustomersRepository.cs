using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NORTHWIND.Models;

namespace NORTHWIND.Services
{
    // Ein *Interface* beschreibt die *GEMEINSAMKEITEN* von verschieden *OBJEKTEN*!
    // z.B. hier definieren wir die Gemeinsamkeiten der Klassenobjekte von:
    // "CsvDataAccess", "MockDataAccess", "SqlDataAccess", "WebDataAccess"
    public interface ICustomersRepository
    {
        // alle Repositories verfügen über grundlegende Operationen:
        // lesen/schreiben/ändern/löschen
        // diese Operationen heißen: CRUD-Operationen
        // <C>reate - erzeugen
        // <R>ead   - lesen
        // <U>pdate - ändern
        // <D>elete - löschen

        public Customer Create(string id, string companyname, string contactname);

        // Interface-Elemente verfügen über *KEINEN* Methodenkörper!
        public IEnumerable<Customer> Get(); // <== *KEINE* Implementierung, d.h. Körper { }
        public Customer Get(string id);

        public void Update(Customer customer);
        public void Update(string id, string newCompanyname, string newContactname);

        public void Delete(Customer customer);
        public void Delete(string id);
    }
}
