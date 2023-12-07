using NORTHWIND.Models;
using NORTHWIND.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWIND.DataAccess
{
    public class CsvDataAccess : ICustomersRepository
    {
        private List<Customer> _customers;

        public CsvDataAccess() 
        {
            _customers = new List<Customer>();

            // Csv Textdatei Ordnerpfad ermitteln
            var pfad = Assembly.GetEntryAssembly().Location;
            var directory = Path.GetDirectoryName(pfad);

            // Csv Textdatei lesen
            var sr = new StreamReader($@"{directory}\NORTHWIND-Customers.csv");

            var zeile = sr.ReadLine();
            while (zeile != null)
            {
                // CSV-Zeile in ihre Bestandteile zerlegen
                var customerData = zeile.Split(';');
                var customerId = customerData[0];
                var companyName = customerData[1];
                var contactName = customerData[2];

                var customer = new Customer()
                {
                    ID = customerId,
                    CompanyName = companyName,
                    ContactName = contactName,
                };
                _customers.Add(customer);

                // nächste CSV-Zeile lesen
                zeile = sr.ReadLine();
            }
        }

        public Customer Create(string id, string companyname, string contactname)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, string newCompanyname, string newContactname)
        {
            throw new NotImplementedException();
        }
    }
}
