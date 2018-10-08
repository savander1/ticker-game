using System;

namespace Ticker.Entities
{
    public class Stock : IStock
    {
        public string Name { get; }
        public decimal Value { get; set; }

        public Stock(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            
            Name = name;
        }
    }
}
