using System;
using Ticker.Entities;

namespace Ticker.Logic.Observers
{
    public class StockObserver : IObserver<IStock>
    {
        private readonly IObservable<IStock> _observable;
        public IStock Stock { get; private set; }

        public StockObserver(IStock stock)
        {
            Stock = stock;
            
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IStock value)
        {
            Stock = value;
            
            
        }
    }
}
