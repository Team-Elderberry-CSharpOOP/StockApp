using System;
using System.ComponentModel;
using System.Threading;

namespace StockApp.Utils
{
    public delegate void ElapsedEventHadler(object sender, EventArgs e);

    class RequestTimer : IRequestTimer
    {
        private event ElapsedEventHadler OnElapsed;

        public void StartWithCallback(int t, ElapsedEventHadler callback)
        {
            SimpleValidator.CheckNull(callback, "Timer callback");

            OnElapsed = callback;

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += (s, e) =>
            {
                while (true)
                {
                    Thread.Sleep(t);
                    this.OnTimedEvent();
                }
            };

            // bw.RunWorkerCompleted += (s, e) => { this.OnTimedEvent(); };

            bw.RunWorkerAsync();
        }

        private void OnTimedEvent()
        {
            if (this.OnElapsed != null)
            {
                this.OnElapsed(this, EventArgs.Empty);
            }
        }
    }
}
