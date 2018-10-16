using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticker.Logic.Engine;
using Timer = Ticker.Logic.Engine.Timer;

namespace Ticker.Logic.Test.Engine
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctr_NullPassed_ThrowsException()
        {
            new Timer(null);
        }

        [TestMethod]
        public void Start_ActionPassed_ActionCalledAsExpected()
        {
            var counter = 0;
            using (var timer = new Timer(() => counter++))
            {
                timer.Start();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            
            Assert.IsTrue(counter > 0);
        }
    }
}