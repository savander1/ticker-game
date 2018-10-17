using System;
using System.Runtime.Serialization;

namespace Ticker.Entities
{
    public interface IStock : IObservable<IStock>, IDisposable, ISerializable
    {
        string Name { get; }
        decimal Value { get; set; }
    }
}