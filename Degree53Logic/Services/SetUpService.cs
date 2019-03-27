using Degree53.Model;
using System;

namespace Degree53.Services
{
    public class SetUpService
    {
        public SetUpService()
        {
        }

        public Catalogue CreateCatalogue()
        {
            var catalogue = new Catalogue();
            try
            {
                catalogue.AddProduct(new Product("A13", 0.50m, "Apple"));
                catalogue.AddProduct(new Product("C45", 1.50m, "Chicken"));
                catalogue.AddProduct(new Product("B15", 2.50m, "Beans"));
                catalogue.AddProduct(new Product("T23", 1.00m, "Tea"));
                catalogue.AddProduct(new Product("B16", 1.50m, "Bannana"));
                catalogue.AddProduct(new Product("B78", 2.50m, "Beer"));
                catalogue.AddProduct(new Product("W13", 4.50m, "Wine"));
                catalogue.AddOffer(new Offer("A13", 3, 1.00m));
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return catalogue;
        }
    }
}
