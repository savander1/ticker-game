using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace Ticker.Logic.Engine
{

    public interface ITimer
    {
        void Start();
        void Stop();
    }

    public class Timer : ITimer, IDisposable
    {
        private const double ONE_SECOND = 1000;
        private readonly System.Timers.Timer _timer;

        public Timer(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            _timer = new System.Timers.Timer(ONE_SECOND);
            _timer.Elapsed += (sender, e) => action();
        }

        public void Start()
        {
            _timer.Enabled = true;
        }

        public void Stop()
        {
            _timer.Enabled = false;
        }

        private bool _disposing;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    _timer.Dispose();
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
