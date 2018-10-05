using System;
using Ticker.Entities;

namespace Ticker.Logic
{
    public class MarketLogic
    {
        private readonly IObservable<IStock> _market;

        public MarketLogic(IObservable<IStock> market, Action<>) 
        {
            _market = market;
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }

        private OnStop


    }
}
