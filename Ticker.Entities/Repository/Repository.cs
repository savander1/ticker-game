using System;

namespace Ticker.Entities.Repository
{
    public class Repository : IRepository
    {
        private readonly string ConnectionString;
        public Repository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            ConnectionString = connectionString;
        }

        public IStock GetStock(string name)
        {
            throw new NotImplementedException();
        }

        public void SetStock(IStock stock)
        {
            throw new NotImplementedException();
        }
    }
}