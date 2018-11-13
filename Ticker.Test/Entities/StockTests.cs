using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ticker.Entities;

namespace Ticker.Test.Entities
{
    [TestClass]
    public class StockTests
    {
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_InvalidParameterPassed_ThrowsException(string param)
        {
            new Stock(param);
        }

        [TestMethod]
        public void Equals_StocksAreEqual_ReturnsTrue()
        {
            var stockA = new Stock("A") { Value = 1 };
            var stockB = new Stock("A") { Value = 1 };

            var areEqual = stockA.Equals(stockB) && stockB.Equals(stockA);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void Equals_SameValueDifferentName_ReturnsFalse()
        {
            var stockA = new Stock("A") { Value = 1 };
            var stockB = new Stock("B") { Value = 1 };

            var areEqual = stockA.Equals(stockB) && stockB.Equals(stockA);

            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void Equals_DifferentValueSameName_ReturnsTrue()
        {
            var stockA = new Stock("A") { Value = 1 };
            var stockB = new Stock("A") { Value = 2 };

            var areEqual = stockA.Equals(stockB) && stockB.Equals(stockA);

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void ValueSet_StockHasObserver_ObserverNotified()
        {
            Stock observed = null;
            var observer = new Mock<IObserver<IStock>>();
            observer.Setup(x => x.OnNext(It.IsAny<IStock>())).Callback<IStock>((s) => observed = s as Stock);
            var stock = new Stock("A") { Value = 1 };
            stock.Subscribe(observer.Object);

            stock.Value = 2;

            observer.Verify(x => x.OnNext(It.IsAny<IStock>()), Times.Once);
            Assert.AreEqual(2, observed.Value);
            Assert.AreEqual(2, stock.Value);
        }
    }
}