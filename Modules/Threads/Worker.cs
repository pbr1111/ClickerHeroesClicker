using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public abstract class Worker
    {
        protected EventWaitHandle wh = new ManualResetEvent(true);
        protected Thread _thread;
        protected IntPtr _hwnd;

        public void ChangeRunState(bool option)
        {
            if (option)
            {
                StartOrResume();
            }
            else
            {
                Pause();
            }
        }

        private void StartOrResume()
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

        private void Pause()
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
