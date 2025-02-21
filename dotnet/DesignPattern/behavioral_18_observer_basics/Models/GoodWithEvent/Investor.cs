using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.GoodWithEvent
{
    public class Investor
    {
        public string Name { get; }
        public Investor(string name)
        {
            Name = name;
        }

        public void OnStockPriceChanged(object sender, StockPriceChangedEventArgs e)
        {
            Console.WriteLine($"{Name} notified: {e.Symbol} new price is {e.NewPrice:C}");
        }
    }
}