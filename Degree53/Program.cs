using Degree53.Services;
using System;

namespace Degree53
{
    public class Program
    {
        static void Main(string[] args)
        {
            var setup = new SetUpService();
            var catalog = setup.CreateCatalogue();

            var scanService = new ScanService(catalog);
            var totalService = new TotalUpService(catalog);

            Console.WriteLine("Checkout service");
            Console.WriteLine("Please enter the code for each item and press enter. Entering 'DONE' will return the total");

            var checkOut = false;
            while (!checkOut)
            {
                var line = Console.ReadLine();
                if (line == "DONE")
                {
                    checkOut = true;
                    Console.WriteLine("Total: " + totalService.TotalUp(scanService.ScannedItems).ToString());
                    Console.ReadLine();
                }
                else {
                    try
                    {
                        scanService.Scan(line);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
