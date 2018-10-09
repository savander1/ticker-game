using System;

namespace Ticker.Entities
{
    public class Stock : IStock, IObservable<IStock>, IDisposable
    {
        private IObserver<IStock> _observer;
        private bool _disposing = false;
        private decimal _value;
        public string Name { get; }
        public decimal Value 
        { 
            get
            {
                return _value;
            }
            set 
            {
                _value = value;
                if (_observer != null)
                {
                    _observer.OnNext(this);
                }
            }
        }

        public Stock(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            
            Name = name;
        }

        public IDisposable Subscribe(IObserver<IStock> observer)
        {
            _observer = observer;
            return this;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    Dispose();
                }

                _disposing = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
