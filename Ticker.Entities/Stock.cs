﻿using System;
using System.Runtime.Serialization;

namespace Ticker.Entities
{
    [Serializable]
    public class Stock : IStock
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

        public override bool Equals(object obj)
        {
            var other = obj as Stock;
            if (other != null)
            {
                return other.Name == Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(this.Name), Name);
            info.AddValue(nameof(this.Value), Value);
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
