using System;
using System.Collections.Generic;
using Ticker.Entities;

namespace Ticker.Logic
{
    public class MarketExecutor : IMarketExecutor
    {
        private readonly IList<IStock> _stocks;
        private readonly MarketSettings _settings;
        private bool _started = false;
        private bool _stopping = false;

        public MarketExecutor(IList<IStock> stocks, MarketSettings settings) 
        {
            _stocks = stocks;
            _settings = settings;
        }

        public void Start()
        {
            if (!_started)
            {
                _started = true;

                    
            }

        }

        public void Stop()
        {

        }

    }

    public class MarketSettings
    {
        public int UpdateInterval {get;set;}
    }
}
