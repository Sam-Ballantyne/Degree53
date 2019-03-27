using System;
using System.Collections.Generic;
using System.Text;

namespace Degree53.Model
{
    public interface ICatalogue
    {
        void AddProduct(Product product);

        void RemoveProduct(string code);

        List<Product> GetAllProducts();

        Product GetProduct(string code);

        void AddOffer(Offer product);

        void RemoveOffer(string code);

        List<Offer> GetAllOffers();

        Offer GetOffer(string code);
    }
}
