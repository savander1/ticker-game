using System;
using Ticker.Entities;

namespace Ticker.Logic
{
    public class MarketExecutor : IMarketExecutor
    {
        private readonly IObservable<IStock> _market;

        public MarketExecutor(IObservable<IStock> market) 
        {
            _market = market;
        }

        public void Start()
        {
        }

        public void Stop()
        {

        }

    }
}
