using System;
using System.Collections.Generic;
using System.Linq;

namespace Degree53.Model
{
    public class Catalogue : ICatalogue
    {
        private List<Product> Products;

        private List<Offer> Offers;

        public Catalogue()
        {
            Products = new List<Product>();
            Offers = new List<Offer>();
        }

        public void AddOffer(Offer offer)
        {
            if (!GetAllProductCodes().Contains(offer.Code))
            {
                throw new Exception("Offer does not refer to existing product");
            }
            else
            {
                Offers.Add(offer);
            }
        }

        public void AddProduct(Product product)
        {
            if (GetAllProductCodes().Contains(product.Code))
            {
                throw new Exception("Product already exists");
            }
            else
            {
                Products.Add(product);
            }
        }

        public List<Offer> GetAllOffers()
        {
            return Offers;
        }

        public List<Product> GetAllProducts()
        {
            return Products;
        }

        public Offer GetOffer(string code)
        {
            return Offers.FirstOrDefault(p => p.Code == code);
        }

        public Product GetProduct(string code)
        {
            var toReturn = Products.FirstOrDefault(p => p.Code == code);
            if (toReturn != null)
            {
                return toReturn;
            }
            else
            {
                throw new Exception("Product could not be found");
            }
        }

        public void RemoveOffer(string code)
        {
            var toRemove = Offers.FirstOrDefault(o => o.Code == code);
            if (toRemove != null)
            {
                Offers.Remove(toRemove);
            }
            else
            {
                throw new Exception("Product could not be found");
            }
        }

        public void RemoveProduct(string code)
        {
            var toRemove = Products.FirstOrDefault(p => p.Code == code);
            if (toRemove != null)
            {
                Products.Remove(toRemove);
                Offers.RemoveAll(o => o.Code == code);
            }
            else
            {
                throw new Exception("Product could not be found");
            }
        }

        private IEnumerable<string> GetAllProductCodes()
        {
            return Products.Select(p => p.Code);
        }

        private IEnumerable<string> GetAllOfferCodes()
        {
            return Offers.Select(o => o.Code);
        }
    }
}
