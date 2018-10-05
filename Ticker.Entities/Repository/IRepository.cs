using System;

namespace Ticker.Entities.Repository
{
    public interface IRepository<T>
    {
        T Get(string name);
        void Set(T stock);
    }
}