using Degree53.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Degree53.Services
{
    public class ScanService
    {
        public Catalogue Catalogue;

        public List<Product> ScannedItems { get; }

        public ScanService(Catalogue catalog)
        {
            Catalogue = catalog;
            ScannedItems = new List<Product>();
        }

        public void Scan(string code)
        {
            try
            {
                ScannedItems.Add(Catalogue.GetProduct(code));
            }
            catch {
                Console.WriteLine("Error scanning items");
            }
            
        }
    }
}
