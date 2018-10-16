using Ticker.Logic.Utils;
using Ticker.Entities;

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
            _stock = stock;
        }

        public void UpdateValue(IDice dice)
        {
            var delta = dice.RollDice();
            _stock.Value += delta;
        }
    }
}
