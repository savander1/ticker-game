using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticker.Entities;
using Ticker.Entities.Exception;

namespace Ticker.Test.Entities
{
    [TestClass]
    public class PlayerTests
    {
        private const string StockName = "Foo";

        [TestMethod]
        public void Ctr_NoParams_PlayerCreatedSuccessFully()
        {
            var player = new Player();

            Assert.IsNotNull(player, "player != null");
            Assert.IsNotNull(player.Stocks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BuyStock_NullPassed_ThrowsException()
        {
            var player = new Player();
            player.BuyStock(null);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BuyStock_InvalidQuantityPassed_ThrowsException(int quantity)
        {
            var player = new Player();
            var stock = new Stock(StockName){ Value = 1M };

            player.BuyStock(stock, quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientCapitalException))]
        public void BuyStock_PlayerLacksCapital_ThrowsException()
        {
            var player = new Player();
            var stock = new Stock(StockName){ Value = 1M };

            player.BuyStock(stock, 10);
        }

        [TestMethod]
        public void BuyStock_NewStock_PlayerUpdated()
        {
            var player = new Player { Capital = 2M};
            var stock = new Stock(StockName){ Value = 1M };

            player.BuyStock(stock);

            Assert.IsTrue(player.Stocks.ContainsKey(stock));
            Assert.AreEqual(1M, player.Capital);
        }

        [TestMethod]
        public void BuyStock_ExistingStock_PlayerUpdated()
        {
            var stock = new Stock(StockName){ Value = 1M };
            var player = new Player 
            { 
                Capital = 2M,
                Stocks = new Dictionary<IStock, int>
                {
                    { stock, 4 }
                }
            };
            
            player.BuyStock(stock);

            Assert.AreEqual(5, player.Stocks[stock]);
            Assert.AreEqual(1M, player.Capital);
        }
    }
}