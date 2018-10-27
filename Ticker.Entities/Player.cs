using System;
namespace Ticker.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Player(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}
