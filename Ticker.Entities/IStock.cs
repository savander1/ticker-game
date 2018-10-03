using System;

namespace Ticker.Entities
{
    public interface IStock
    {
        string Name { get; }
        double Value { get; set; }
    }
}