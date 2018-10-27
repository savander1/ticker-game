using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticker.Logic.Utils;

namespace Ticker.Test.Logic.Utils
{
    [TestClass]
    public class RandomizerTests
    {
        [TestMethod]
        public void GetRanddomItemFrom_NullList_ReturnsDefault()
        {
            var randomizer = new Randomizer();

            var result = randomizer.GetRandomItemFrom((IList<int>)null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetRanddomItemFrom_EmptyList_ReturnsDefault()
        {
            var randomizer = new Randomizer();
            var list = GenerateUniqueList(0);

            var result = randomizer.GetRandomItemFrom(list);

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void GetRandomItemFrom_ListOfInt_RandomSelectionReturned()
        {
            const int num = 1000;
            var randomizer = new Randomizer();
            var list = GenerateUniqueList(num);

            var results = new List<int>();
            for (var i = 0; i < num; i++)
            {
                results.Add(randomizer.GetRandomItemFrom(list));
            }


            CollectionAssert.AllItemsAreUnique(results.Take(10).ToList());
        }





        private IList<int> GenerateUniqueList(int numElements)
        {
            var list = new List<int>();
            for (var i = 1; i <= numElements; i++)
            {
                list.Add(i);
            }
            return list;
        }

    }
}
