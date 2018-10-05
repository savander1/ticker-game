using System;

namespace Ticker.Entities.Repository
{
    public interface IRepository<T> where T: class
    {
        T Get(string name);
        void Set(T stock);
    }
}