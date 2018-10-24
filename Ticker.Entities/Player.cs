﻿using System;
using System.Collections.Generic;
using Ticker.Entities.Exception;

namespace Ticker.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Capital  {get; set; }
        public IDictionary<IStock, int> Stocks { get; set; }

        public Player()
        {
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
    }
}
