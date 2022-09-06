using System;
using System.Threading.Tasks;
using App.Sale.Infraestructure.Data.Contexts;

namespace App.Sale.Infraestructure.Data
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Creating Database if not exists!");
            SaleContext db = new SaleContext();
            await db.Database.EnsureCreatedAsync();
            Console.WriteLine("Ready!");
            Console.ReadKey();

        }
    }
}
