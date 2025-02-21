using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.GoodWithEvent
{
    public class StockPriceChangedEventArgs : EventArgs
    {
        public string Symbol { get; }
        public decimal NewPrice { get; }

        public StockPriceChangedEventArgs(string symbol, decimal newPrice)
        {
            Symbol = symbol;
            NewPrice = newPrice;
        }
    }
}