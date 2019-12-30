using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBreakfast
{
    class Program
    {
        static async Task HeatPan()
        {
            Console.WriteLine("0. The pan will be heated after ingredients will finish mixing");
            await MixIngredients();
            Console.WriteLine("3. Pan heated to cooking temperature");
        }

        static Task MixIngredients()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("1. Mixing ingredients");
                for (int i = 0; i < 100000000; i++) ;
                Console.WriteLine("2. Done mixing ingredients");
            });

            t.Start();
            return t;
        }

        static async Task<bool> AddToPan()
        {
            Task<bool> t = new Task<bool>(() =>
            {
                Console.WriteLine("4. Adding ingredients to pan");
                for (int i = 0; i < 100000000; i++) ;
                Console.WriteLine("5. Cooking Finished");
                return true;
            });

            await HeatPan();
            t.Start();

            return t.Result;
        }

        static async Task<bool> Serve()
        {
            await AddToPan();
            Task<bool> t = new Task<bool>(() =>
            {
                for (int i = 0; i < 100000000; i++) ;
                Console.WriteLine("6. Breakfast served");
                return true;
            });

            t.Start();

            return t.Result;
        }

        static void Main(string[] args)
        {
            // tells main thread to wait for Serve() since Main is not a async method
            Serve().Wait();
        }
    }
}
