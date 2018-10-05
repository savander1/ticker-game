using System;
using System.Collections.Generic;
using Ticker.Entities;
using Ticker.Logic.Subjects;

namespace Ticker.Logic
{
    public class MarketLogic
    {
        private readonly IMarketExecutor _executor;
        private readonly IList<IStock> _stocks;

        public MarketLogic(IList<IStock> stocks)
        {
            _stocks = stocks;

            foreach (var stock in _stocks)
            {
                var observer = new StockObserver(_stocks)
            }
        }
    }

    public interface IMarketLogic
    {

    }
}
