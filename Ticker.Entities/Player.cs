using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ticker.Entities.Exception;

namespace Ticker.Entities
{
    public class Player : ISerializable
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public decimal Capital  {get; set; }
        public IDictionary<IStock, int> Stocks { get; set; }

        public Player(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Stocks = new Dictionary<IStock, int>();
        }

        public void BuyStock(IStock stock, int quantity = 1)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            UpdateCapital(stock.Value, quantity);
            if (Stocks.ContainsKey(stock))
            {
                Stocks[stock] += quantity;
            }
            else
            {
                Stocks.Add(stock, quantity);
            }
        }

        public void SellStock(IStock stock, int quantity = 1)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            
            if (Stocks.ContainsKey(stock))
            {
                if (quantity > Stocks[stock])
                {
                    UpdateCapital(stock.Value, Stocks[stock] * -1);
                    Stocks.Remove(stock);
                }
                else 
                {
                    UpdateCapital(stock.Value, quantity * -1);
                    Stocks[stock] -= quantity;
                }
            }
        }

        private void UpdateCapital(decimal value, int quantity)
        {
            var cost = value * quantity;
            if ((Capital - cost) <= 0M)
                throw new InsufficientCapitalException();
            
            Capital -= cost;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.Id), Id);
            info.AddValue(nameof(this.Name), Name);
            info.AddValue(nameof(this.Capital), Capital);
            info.AddValue(nameof(this.Stocks), Stocks);
        }
    }
}
