using System;
using System.IO;

namespace Ticker.Logic
{
    public class SerializerConfig
    {
        public string SerializerPath { get; set; }
        public Guid Id { get; private set; }
        public string FilePath => Path.Combine(SerializerPath, Id.ToString());

        public SerializerConfig(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}