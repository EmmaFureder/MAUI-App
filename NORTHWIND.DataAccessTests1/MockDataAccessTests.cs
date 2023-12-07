using Microsoft.VisualStudio.TestTools.UnitTesting;
using NORTHWIND.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NORTHWIND.DataAccess.Tests
{
    [TestClass()]
    public class MockDataAccessTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            // ctor von MockDataAccess erzeugt 3 Elemente
            var dataAccess = new MockDataAccess();

            var customers = dataAccess.Get();

            // Annahme: customers Anzahl MUSS 3 sein! (IsTrue)
            Assert.IsTrue(customers.Count() == 3);

            var newCustomer = dataAccess.Create("TESTID", "Testfirma", "Testkontaktperson");

            // Testannahmen durchführen, z.B. "newCustomer.ID" muss "TESTID" lauten, usw.
            Assert.IsTrue(newCustomer.ID == "TESTID");
            Assert.IsTrue(newCustomer.CompanyName == "Testfirma");
            Assert.IsTrue(newCustomer.ContactName == "Testkontaktperson");

            customers = dataAccess.Get();
            // Testannahme: die Anzahl der Kunden muss jetzt 4 sein!
            Assert.IsTrue(customers.Count() == 4);

            // Annahme!
            // Assert.Fail();
        }
    }
}