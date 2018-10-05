using System;
using System.Collections.Generic;
using Ticker.Entities;
using Ticker.Logic.Observers;
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
            var market = new Market();

            foreach (var stock in _stocks)
            {
                var observer = new StockObserver(stock);
                market.Subscribe(observer);
            }
        }

        
    }

    public interface IMarketLogic
    {

    }
}
