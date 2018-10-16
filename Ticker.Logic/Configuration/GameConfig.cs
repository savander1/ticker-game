using System.Collections.Generic;

namespace Ticker.Logic
{
    public class GameConfig
    {
        public LoadType Type { get; set; }
        public IList<string> StockNames { get; set; }
        public int InitialValue { get; set; }
        public int MaxDelta { get; set; }

        public enum LoadType
        {
            New,
            Load
        }
        
    }
}