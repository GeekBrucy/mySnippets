using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.GoodWithEvent
{
    public class ObserverEventApp
    {
        public static void Run()
        {
            var stock = new Stock("MSFT", 100);
            var investor1 = new Investor("John");
            var investor2 = new Investor("Jane");

            stock.PriceChanged += investor1.OnStockPriceChanged;
            stock.PriceChanged += investor2.OnStockPriceChanged;

            stock.UpdatePrice(105);
            stock.UpdatePrice(110);
            stock.UpdatePrice(110);
            stock.PriceChanged -= investor1.OnStockPriceChanged;
            stock.UpdatePrice(103);
        }
    }
}