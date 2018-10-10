using System;

namespace Ticker.Entities
{
    public interface IStock : IObservable<IStock>, IDisposable
    {
        string Name { get; }
        decimal Value { get; set; }
    }
}