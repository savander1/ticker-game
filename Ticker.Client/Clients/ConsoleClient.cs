using System;
using Ticker.Entities;
using Ticker.Logic;

namespace Ticker.Client
{
    public class ConsoleClient : Client
    {

        protected override GameConfig GetGameConfig()
        {
            string name = null;
            while(string.IsNullOrEmpty(name))
            {
                Console.Write("Enter Your Name: ");
                name = Console.ReadLine();
            }

            var player = new Player()
            {
                Name = name
            };

            var serializerConfig = GetSerializerConfig(player);
            var config = new GameConfig
            {
                SerializerConfig = serializerConfig,
                StockNames = ElegibleStocks,
                Type = GameConfig.LoadType.New

            };

            return config;
        }
    }
}