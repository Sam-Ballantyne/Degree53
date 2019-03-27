using Degree53.Model;
using System.Collections.Generic;
using System.Linq;

namespace Degree53.Services
{
    public class TotalUpService
    {
        public Catalogue Catalogue;

        public TotalUpService(Catalogue catalog)
        {
            Catalogue = catalog;
        }

        public decimal TotalUp(List<Product> products)
        {
            var distinctCodes = products.GroupBy(x => x.Code).Select(x => x.FirstOrDefault()).Select(x => x.Code);
            var total = 00.00m;

            foreach (var code in distinctCodes)
            {
                var productsOfCode = products.Where(x => x.Code == code);
                var offer = Catalogue.GetOffer(code);
                if (offer == null || offer.Quantity > productsOfCode.Count())
                {
                    total += productsOfCode.Sum(p => p.Cost);
                }
                else {
                    total += ApplyOffer(productsOfCode.First(), offer, productsOfCode.Count());
                }

            }
            return total;
        }

        private decimal ApplyOffer(Product product, Offer offer, int quantity)
        {
            var timesApplied = quantity / offer.Quantity;
            var remained = quantity % offer.Quantity;
            return (offer.Cost * timesApplied) + (remained * product.Cost);
        }
    }
}
