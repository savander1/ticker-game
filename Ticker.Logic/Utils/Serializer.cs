using System;
using System.Collections.Generic;
using Ticker.Entities;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Ticker.Logic.Utils
{
    public interface ISerializer
    {
        void Serialize<T>(T t) where T : class;
        T Deserialize<T>() where T : class;
    }

    public class Serializer : ISerializer
    {
        private readonly string _path;
        public Serializer(SerializerConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            _path = Path.Combine(config.SerializerPath, config.Id.ToString());
        }
        public T Deserialize<T>() where T : class
        {
            using (var stream = new FileStream(_path, FileMode.Open, FileAccess.Read))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        public void Serialize<T>(T t) where T : class
        {
            using (var stream = new FileStream(_path, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
            }
        }
    }
}