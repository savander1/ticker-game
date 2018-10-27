using System;
using System.Collections.Generic;
using System.IO;
using Ticker.Entities;
using Ticker.Logic;

namespace Ticker.Client
{
    public abstract class Client
    {
        protected IList<string> ElegibleStocks { get; private set; }
        protected string SerializerBasePath { get; private set; }

        protected Client()
        {
            ElegibleStocks = new List<string>
            {
                "Gold",
                "Oil",
                "Siver",
                "Bonds",
                "Grain",
                "Industrial"
            };

            SerializerBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".gamefiles");
        }

        protected SerializerConfig GetSerializerConfig(Player player)
        {
            return new SerializerConfig()
            {
                SerializerPath = Path.Combine(SerializerBasePath, player.Id.ToString())
            };
        }

        protected abstract GameConfig GetGameConfig();
    }
}
