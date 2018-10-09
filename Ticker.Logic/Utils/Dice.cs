
using System.Collections.Generic;

namespace Ticker.Logic.Utils
{
    public interface IDice
    {
        decimal RollDice();
    }

    public class Dice
    {
        private readonly int _maxDelta;

        public Dice(int maxDelta)
        {
            _maxDelta = maxDelta;
        }   

        public decimal RollDice()
        {
            var directions = new List<Direction> { Direction.Up, Direction.Down };
            var prepostions = new List<Preposition> { Preposition.Under, Preposition.Over };

            var randomizer = new Randomizer();
            var dir = randomizer.GetRandomItemFrom(directions);
            var prep = randomizer.GetRandomItemFrom(prepostions);

            var dec = randomizer.GetRandomValue(99) / 100;

            if (prep == Preposition.Over)
            {
                dec += randomizer.GetRandomValue(_maxDelta - 1);
            }

            if (dir == Direction.Down)
            {
                dec *= -1;
            }

            return dec;
        }

        private enum Direction
        {
            Up,
            Down
        }

        private enum Preposition
        {
            Under,
            Over
        }
    }    
}