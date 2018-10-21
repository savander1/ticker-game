using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticker.Entities;
using Ticker.Logic.Engine;
using Ticker.Logic.Utils;

namespace Ticker.Logic
{
    public class Game
    {
        private IList<IStock> _stocks;
        private readonly IList<IStockValuator> _valuators;
        private readonly IDice _dice;
        private readonly ITimer _timer;
        private readonly ISerializer _serializer;

        public Game(GameConfig config)
        {
            _dice = new Dice(config.MaxDelta);
            _timer = new Timer(() => Run());
            _serializer = new Serializer(config.SerializerConfig);

            switch (config.Type)
            {
                case GameConfig.LoadType.Load:
                    _stocks = _serializer.Deserialize<IList<IStock>>();
                    break;
                case GameConfig.LoadType.New:
                    _stocks = InitStocks(config.StockNames, config.InitialValue);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Load Type");
            }

            _valuators = InitValuator(_stocks);
            
        }

        public void Start()
        {
            // add list of client observers
            _timer.Start();
        }

        public void Save()
        {
            var inPlay = _timer.Running();
            if (inPlay)
            {
                _timer.Stop();
            }

            _serializer.Serialize(_stocks);

            if (inPlay)
            {
                _timer.Start();
            }
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

        private void Run()
        {
            var tasks = new List<Task>();
            foreach(var valuator in _valuators)
            {
                tasks.Add(new Task(() =>  valuator.UpdateValue(_dice)));
            }

            Task.WaitAll(tasks.ToArray());
        }

    }
}