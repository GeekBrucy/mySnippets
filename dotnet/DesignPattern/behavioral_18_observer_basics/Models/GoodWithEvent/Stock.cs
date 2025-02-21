using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace behavioral_18_observer_basics.Models.GoodWithEvent
{
    public class Stock
    {
        public string Symbol { get; }
        private decimal _price;

        public event EventHandler<StockPriceChangedEventArgs> PriceChanged;

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            _price = price;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (_price != newPrice)
            {
                _price = newPrice;
                PriceChanged?.Invoke(this, new StockPriceChangedEventArgs(Symbol, newPrice));
            }
        }
    }
}