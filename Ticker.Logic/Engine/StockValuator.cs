using Ticker.Logic.Utils;
using Ticker.Entities;
using System;

namespace Ticker.Logic
{
    public interface IStockValuator
    {
        void UpdateValue(IDice dice);
    }

    public class StockValuator : IStockValuator
    {
        private readonly IStock _stock;
        public StockValuator(IStock stock)
        {
            _stock = stock ?? throw new ArgumentNullException(nameof(stock));
        }

        public void UpdateValue(IDice dice)
        {
            if (dice == null) throw new ArgumentNullException(nameof(dice));
            
            var delta = dice.RollDice();
            _stock.Value += delta;
        }
    }
}
