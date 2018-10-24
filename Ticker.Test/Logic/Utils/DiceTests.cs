using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticker.Logic.Utils;

namespace Ticker.Test.Logic.Utils
{
    [TestClass]
    public class DiceTests
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctr_InvalidMaxDeltaPassed_ThrowsException(int delta)
        {
            new Dice(delta);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(1000)]
        [DataRow(10000)]
        [DataRow(100000)]
        public void RoleDice_ValidMaxDeltaPassed_ChangeWithinThreshold(int delta)
        {
            var dice = new Dice(delta);

            var result = dice.RollDice();

            Assert.IsTrue(Math.Abs(result) < delta);
        }
    }
}