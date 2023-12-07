using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NORTHWIND.Models;
using NORTHWIND.Services;

namespace NORTHWIND.DataAccess;

public class MockDataAccess : ICustomersRepository
{
    // einen "Customer" Array anstelle der "List<...>" nutzen
    private Customer[] _customers;
    // private List<Customer> _customers;

    public MockDataAccess()
    {
        _customers = new Customer[]
        {
            new Customer()
            {
                ID = "FUCHS",
                CompanyName = "Fuchs Softwareschmiede",
                ContactName = "Fuchs Hannah"
            },
            new Customer()
            {
                ID = "LEIBES",
                CompanyName = "Sportartikel Leibetseder",
                ContactName = "Leibetseder Yanick"
            },
            new Customer()
            {
                ID = "ALFKI",
                CompanyName = "Alfreds Futterkiste",
                ContactName = "Maria Anders"
            }
        };
    }

    public Customer Create(string id, string companyname, string contactname)
    {
        var newCustomers = new Customer[_customers.Length + 1];

        var i = 0;
        foreach(var c in _customers)
        {
            newCustomers[i++] = c;
        }
        newCustomers[i] = new Customer() { 
            ID = id, 
            CompanyName = companyname, 
            ContactName = contactname 
        };

        // bug fix: 
        _customers = newCustomers;

        return newCustomers[i];
    }

    // Verwendung des Interfaces "IEnumerable"
    // *enumerable* bedeutet *aufzählbar* mittels z.B. "foreach"

    // *Interfaces* (Schnittstelle) *beschreiben*, was Objekte können
    // d.h. welche Methoden sie anbieten
    public IEnumerable<Customer> Get()
    {
        return _customers;
    }

    public Customer Get(string id)
    {
        //Customer gesuchterKunde = null;

        //for(int i=0; i < _customers.Length; i++)
        //{
        //    if (_customers[i].ID == id)
        //    {
        //        gesuchterKunde= _customers[i];
        //        break;
        //    }
        //}
        //foreach(var c in _customers)
        //{
        //    if (c.ID == id)
        //    {
        //        gesuchterKunde = c;
        //        break;
        //    }
        //}

        // Verwendung von Lambda-Ausdrücken: x => ... 
        // Lambda-Ausdrücke sind *namenlose* (anonyme) Methoden!
        // Lambda-Ausdrücke sind nichts anderes wie *Abkürzungen*!
        // Aufbau: *KEIN METHODENNAME* (Parameterliste) "=>" Methoden-Körper
        // besteht die Parameterliste nur aus einem Parameter, darf die Klammerung (...) wegfallen
        // Parametertypen dürfen auch weggelassen werden!
        // besteht der Methodenkörper nur aus einer Anweisung, darf die Klammerung {...} wegfallen
        // bei simplen true/false Methoden darf zusätzlich "return" wegfallen
        // "delegate" bedeute *delegieren* der Ausführung zur *anonymen* Methode
        // "delegate" wird durch "=>" abgekürzt
        // var gesuchterKunde = _customers.FirstOrDefault(delegate (Customer c) { return c.ID == id; });

        // "c" ist die Laufvariable der foreach-Schleife innerhalb von "FirstOrDefault"
        var gesuchterKunde = _customers.FirstOrDefault(c => c.ID == id);

        return gesuchterKunde;
    }

    public void Update(Customer customer) // Methodenkopf Name(Parameterliste)
    {                                     // Methodenkörper  
        Update(customer.ID, customer.CompanyName, customer.ContactName);
    }

    public void Update(string id, string newCompanyname, string newContactname)
    {
        var zuändernderKunde = _customers.FirstOrDefault(c => c.ID == id);

        if (zuändernderKunde != null) // Customer zum Ändern wurde gefunden?
        {
            zuändernderKunde.CompanyName = newCompanyname;
            zuändernderKunde.ContactName = newContactname;
        }
    }

    public void Delete(Customer customer)
    {
        Delete(customer.ID);
    }

    public void Delete(string id)
    {
        var zuLöschenderKunde = _customers.FirstOrDefault(k => k.ID == id);

        if (zuLöschenderKunde != null)
        {
            var remainingCustomers = new Customer[_customers.Length - 1];

            int i = 0;
            foreach (var c in _customers)
            {
                if (c.ID != zuLöschenderKunde.ID)
                {
                    remainingCustomers[i++] = c;
                }
            }
            _customers = remainingCustomers;
        }
    }

}
