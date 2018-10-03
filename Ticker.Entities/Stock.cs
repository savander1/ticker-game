using System;

namespace Ticker.Entities
{
    public class Stock : IStock
    {
        private readonly string _name;
        public string Name { get => _name; }
        public double Value { get; set; }

        public Stock(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            
            _name = name;
        }
    }
}
