using System;
using System.Collections.Generic;
using System.Linq;
using Ticker.Entities;
using Ticker.Logic.Engine;
using Ticker.Logic.Utils;

namespace Ticker.Logic
{
    public class Game
    {
        private readonly IList<IStock> _stocks;
        private readonly IList<IStockValuator> _valuators;
        private readonly IDice _dice;
        private readonly ITimer _timer;

        public Game(GameConfig config)
        {
            if (config.Type == GameConfig.LoadType.New)
            {
                _stocks = InitStocks(config.StockNames, config.InitialValue);
            }

            if (_stocks == null) throw new InvalidOperationException("Invalid Load Type");

            _valuators = InitValuator(_stocks);
            _dice = new Dice(config.MaxDelta);


        }

        public void Start()
        {
            
        }

        public void Delete()
        {
            
        }

        private IList<IStockValuator> InitValuator(IList<IStock> stocks)
        {
            return stocks.Select(s => new StockValuator(s) as IStockValuator).ToList();
        }

        private IList<IStock> InitStocks(IList<string> stockNames, int initialValue)
        {
            return stockNames.Select(s => new Stock(s) { Value = initialValue } as IStock).ToList();
        }

        private void Run

    }
}