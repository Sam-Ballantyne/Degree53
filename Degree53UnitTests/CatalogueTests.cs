using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Degree53.Model;
using System.Linq;

namespace Degree53UnitTests
{
    [TestClass]
    public class CatalogueTests
    {
        public Catalogue Catalogue;

        [TestInitialize]
        public void CatalogueTestSetUp()
        {
            Catalogue = new Catalogue();
        }

        [TestMethod]
        public void AddProductWhichDoesNotExist()
        {
            var product = new Product("A12", 00.25m, "Apples");
            Catalogue.AddProduct(product);
            Assert.AreEqual(Catalogue.GetAllProducts().First(), product);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddProductWhichDoesExist()
        {
            var productOne = new Product("A12", 00.25m, "Apples");
            var productTwo = new Product("A12", 00.25m, "Apples");
            Catalogue.AddProduct(productOne);
            Catalogue.AddProduct(productTwo);
        }

        [TestMethod]
        public void AddOfferToExistingProduct()
        {
            var offer = new Offer("A12", 3, 00.50m);
            Catalogue.AddProduct(new Product("A12", 00.25m, "Apples"));
            Catalogue.AddOffer(offer);
            Assert.AreEqual(Catalogue.GetOffer("A12"), offer);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddOfferToNonExistingProduct()
        {
            Catalogue.AddOffer(new Offer("A12", 3, 00.50m));
        }

        [TestMethod]
        public void GetExistingProductFromCatalogue()
        {
            var product = new Product("A12", 00.25m, "Apples");
            Catalogue.AddProduct(product);
            Assert.AreEqual(Catalogue.GetProduct("A12"), product);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetNonExistantProduct()
        {
            Catalogue.GetProduct("XXX");
        }

        [TestMethod]
        public void GetNonExistantOffer()
        {
            var offer = Catalogue.GetOffer("XXX");
            Assert.IsNull(offer);
        }

        [TestMethod]
        public void RemoveExistingOffer()
        {
            var offer = new Offer("A12", 3, 00.50m);
            Catalogue.AddProduct(new Product("A12", 00.25m, "Apples"));
            Catalogue.AddOffer(offer);
            Catalogue.RemoveOffer("A12");
            Assert.AreEqual(Catalogue.GetAllOffers().Count(), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveNonExistingOffer()
        {
            Catalogue.RemoveOffer("A12");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveNonExistingProduct()
        {
            Catalogue.RemoveProduct("A12");
        }

        [TestMethod]
        public void RemoveExistingProduct()
        {
            Catalogue.AddProduct(new Product("A12", 00.25m, "Apples"));
            Catalogue.RemoveProduct("A12");
            Assert.AreEqual(Catalogue.GetAllProducts().Count(), 0);
        }

        [TestMethod]
        public void RemoveExistingProductWithOffer()
        {
            Catalogue.AddProduct(new Product("A12", 00.25m, "Apples"));
            Catalogue.AddOffer(new Offer("A12", 3, 00.50m));
            Catalogue.RemoveProduct("A12");
            Assert.AreEqual(Catalogue.GetAllOffers().Count(), 0);
        }

        [TestMethod]
        public void RemoveExistingProductWithManyOffers()
        {
            Catalogue.AddProduct(new Product("A12", 00.25m, "Apples"));
            Catalogue.AddOffer(new Offer("A12", 3, 00.50m));
            Catalogue.AddOffer(new Offer("A12", 4, 01.50m));
            Catalogue.AddOffer(new Offer("A12", 5, 02.50m));
            Catalogue.AddOffer(new Offer("A12", 6, 02.60m));
            Catalogue.RemoveProduct("A12");
            Assert.AreEqual(Catalogue.GetAllOffers().Count(), 0);
        }
    }
}
