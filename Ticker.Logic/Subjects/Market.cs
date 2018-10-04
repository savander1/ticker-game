using System;
using System.Collections.Generic;
using Ticker.Entities;

namespace Ticker.Logic.Subjects 
{
    public class Market : IObservable<IStock>
    {
        private IList<IObserver<IStock>> _observers;

        public Market()
        {
            _observers = new List<IObserver<IStock>>();
        }

        public IDisposable Subscribe(IObserver<IStock> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber<IStock>(_observers, observer);
        }

        public void Update(IStock stock)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(stock);
            }
        }

        private class Unsubscriber<IStock> : IDisposable
        {
            private IList<IObserver<IStock>> _observers;
            private IObserver<IStock> _observer;

            internal Unsubscriber(IList<IObserver<IStock>> observers, IObserver<IStock> observer)
            {
                _observers = observers;
                _observer = observer;
            }
            public void Dispose()
            {
                if (_observers.Contains(_observer))
                {
                     _observers.Remove(_observer);
                }
            }
        }
    }
}