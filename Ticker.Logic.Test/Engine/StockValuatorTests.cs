using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ticker.Entities;
using Ticker.Logic.Utils;

namespace Ticker.Logic.Test.Engine
{
    [TestClass]
    public class StockValuatorTests
    {
        private Mock<IDice> _dice;
        private static decimal DiceValue = 1.2M;

        [TestInitialize]
        public void Init()
        {
            _dice = new Mock<IDice>();
            _dice.Setup(x => x.RollDice()).Returns(DiceValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_NullPassed_ThrowsException()
        {
            new StockValuator(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateValue_NullPassed_ThrowsException()
        {
            var stock = new Stock("foo"){ Value = 1M };
            var valuator = new StockValuator(stock);

            valuator.UpdateValue(null);
        }

        [TestMethod]
        public void UpdateValue_DicePassed_DiceCalledAsExpected()
        {
            var stock = new Stock("foo"){ Value = 1M };
            var valuator = new StockValuator(stock);

            valuator.UpdateValue(_dice.Object);

            _dice.Verify(x => x.RollDice(), Times.Once);
        }

        [TestMethod]
        public void UpdateValue_DicePassed_ValueUpdatedAsExpected()
        {
            var stock = new Stock("foo"){ Value = 1M };
            var valuator = new StockValuator(stock);

            valuator.UpdateValue(_dice.Object);

           Assert.AreEqual(2.2M, stock.Value);
        }
    }
}