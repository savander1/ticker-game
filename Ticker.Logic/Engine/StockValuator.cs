using System;
using Ticker.Logic.Utils;
using Ticker.Entities;
using System.Collections.Generic;

namespace Ticker.Logic
{
    public class StockValuator
    {
        private readonly IStock _stock;
        public StockValuator(IStock stock)
        {
            _stock = stock;
        }

        public void UpdateValue(IDice dice)
        {
            var delta = dice.RollDice();
            _stock.Value += delta;
        }
    }
}
