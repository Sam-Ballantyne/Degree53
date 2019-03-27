using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Degree53.Model;
using System.Linq;
using Degree53.Services;

namespace Degree53UnitTests
{
    [TestClass]
    public class ScanServiceUnitTests
    {
        public ScanService ScanService;

        [TestInitialize]
        public void ScanServiceTestSetUp()
        {
            var catalog = new Catalogue();
            catalog.AddProduct(new Product("A13", 0.50m, "Apple"));
            catalog.AddProduct(new Product("C45", 1.50m, "Chicken"));
            catalog.AddProduct(new Product("B15", 2.50m, "Beans"));
            catalog.AddProduct(new Product("T23", 1.00m, "Tea"));

            ScanService = new ScanService(catalog);
        }

        [TestMethod]
        public void ScanCodeWhichDoesNotExist()
        {
            ScanService.Scan("XXX");
            Assert.AreEqual(ScanService.ScannedItems.Count(), 0);
        }

        [TestMethod]
        public void ScanCodeWhichDoesExist()
        {
            ScanService.Scan("A13");
            Assert.AreEqual(ScanService.ScannedItems.Count(), 1);
        }

        [TestMethod]
        public void ScanMultipleValidItems()
        {
            ScanService.Scan("A13");
            ScanService.Scan("A13");
            ScanService.Scan("C45");
            ScanService.Scan("A13");
            ScanService.Scan("B15");
            Assert.AreEqual(ScanService.ScannedItems.Count(), 5);
        }
    }
}
