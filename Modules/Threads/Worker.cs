using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public abstract class Worker
    {
        protected EventWaitHandle wh;
        protected Thread _thread;
        protected IntPtr _hwnd;
        private bool Running;

        public Worker(IntPtr hwnd)
        { 
            wh = new ManualResetEvent(true);
            _hwnd = hwnd;
            Running = false;
        }

        public bool IsRunning()
        {
            return Running;
        }

        public void ChangeRunState()
        {
            if (!Running)
            {
                StartOrResume();
                Running = true;
            }
            else
            {
                Pause();
                Running = false;
            }
        }

        public void Stop()
        {
            if (_thread.ThreadState == ThreadState.Running)
            {
                _thread.Join();
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
    }
}
