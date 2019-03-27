using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Degree53.Model;
using System.Linq;
using Degree53.Services;
using System.Collections.Generic;

namespace Degree53UnitTests
{
    [TestClass]
    public class TotalUpServiceUnitTests
    {
        public TotalUpService TotalService;

        [TestInitialize]
        public void TotalUpServiceSetUp()
        {
            var catalog = new Catalogue();
            catalog.AddProduct(new Product("A13", 0.50m, "Apple"));
            catalog.AddProduct(new Product("C45", 1.50m, "Chicken"));
            catalog.AddProduct(new Product("B15", 2.50m, "Beans"));
            catalog.AddProduct(new Product("T23", 1.00m, "Tea"));

            catalog.AddOffer(new Offer("A13", 3, 1.00m));
            catalog.AddOffer(new Offer("C45", 4, 4.00m));

            TotalService = new TotalUpService(catalog);
        }

        [TestMethod]
        public void ScanMultipleOfSameItemWithNoDeal()
        {
            var scannedItems = new List<Product>()
            {
                new Product("T23", 1.00m, "Tea"),
                new Product("T23", 1.00m, "Tea"),
                new Product("T23", 1.00m, "Tea")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 3.00m); 
        }

        [TestMethod]
        public void ScanDifferentItemsWithNoDeals()
        {
            var scannedItems = new List<Product>()
            {
                new Product("T23", 1.00m, "Tea"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("B15", 2.50m, "Beans")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 5.00m);
        }

        [TestMethod]
        public void CheckBasicOfferWorks()
        {
            var scannedItems = new List<Product>()
            {
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 1.00m);
        }

        [TestMethod]
        public void CheckOfferAndRemainderWorks()
        {
            var scannedItems = new List<Product>()
            {
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 1.50m);
        }

        [TestMethod]
        public void CheckMultipleOffersAreCorrectlyApplied()
        {
            var scannedItems = new List<Product>()
            {
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("C45", 1.50m, "Chicken"),
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 5.00m);
        }

        [TestMethod]
        public void TestItemsOutOfOrderDoesNotMatter()
        {
            var scannedItems = new List<Product>()
            {
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 5.00m);
        }

        [TestMethod]
        public void TestOfferCanBeAppliedToMultipleBatches()
        {
            var scannedItems = new List<Product>()
            {
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple"),
                new Product("A13", 0.50m, "Apple")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 2.00m);
        }

        [TestMethod]
        public void TestLongListWithMultipleOffers()
        {
            var scannedItems = new List<Product>()
            {
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple"),
                new Product("T23", 1.00m, "Tea"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("C45", 1.50m, "Chicken"),
                new Product("A13", 0.50m, "Apple"),
                new Product("B15", 2.50m, "Beans"),
                new Product("B15", 2.50m, "Beans")
            };
            Assert.AreEqual(TotalService.TotalUp(scannedItems), 11.00m);
        }
    }
}

