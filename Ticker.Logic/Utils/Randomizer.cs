using System;
using System.Collections.Generic;
using System.Linq;

namespace Ticker.Logic.Utils
{
    public class Randomizer
    {
        private static readonly Random Random = new Random();
        private readonly Random _random;

        public Randomizer()
        {
            _random = new Random(Random.Next());
        }

        public T GetRandomItemFrom<T>(IList<T> items)
        {
            if (items == null || !items.Any()) return default(T);
            var count = items.Count - 1;
            
            return count == 0 ? items[0] : items[_random.Next(count)];
        }
    }
}