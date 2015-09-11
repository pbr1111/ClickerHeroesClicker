using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
