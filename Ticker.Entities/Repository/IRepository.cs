using System;

namespace Ticker.Entities.Repository
{
    public interface IRepository
    {
        IStock GetStock(string name);
        void SetStock(IStock stock);
    }
}