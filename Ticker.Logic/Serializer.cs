using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Ticker.Logic
{
    public class Serializer
    {
        private readonly SerializerConfig _config;

        public Serializer(SerializerConfig config)
        {
            _config = config;
        }
        public void Serialize<T>(T obj)
        {
            using (var stream = new FileStream(GetFilePath(obj), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            using (var writer = new BinaryWriter(stream, Encoding.UTF32))
            {
                writer.Write(JsonConvert.SerializeObject(obj));
            }
        }

        private string GetFilePath<T>(T obj)
        {
            return _config.SerializerPath;
        }
    }

    public class SerializerConfig
    {
        public string SerializerPath { get; set; }
    }
}