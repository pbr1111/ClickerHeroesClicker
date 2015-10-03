using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules
{
    public abstract class Worker
    {
        protected EventWaitHandle wh = new ManualResetEvent(true);
        protected Thread _thread;
        protected IntPtr _hwnd;

        public void StartOrResume()
        {
            if (_thread.ThreadState == ThreadState.Unstarted)
            {
                _thread.Start();
            }
            else
            {
                wh.Set();
            }
        }

        public void Pause()
        {
            wh.Reset();
        }

        public void Stop()
        {
            if (_thread.ThreadState == ThreadState.Running)
            {
                _thread.Join();
            }
        }
    }
}
