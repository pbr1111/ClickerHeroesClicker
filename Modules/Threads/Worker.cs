using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public abstract class Worker
    {
        protected Timer Timer;
        protected int PeriodTime;
        protected IntPtr Hwnd;
        private bool Running;

        public Worker(IntPtr hwnd, int periodTime)
        {
            Hwnd = hwnd;
            Timer = new Timer(new TimerCallback(Run));
            PeriodTime = periodTime;
            Running = false;
        }

        protected abstract void Run(object args);

        public bool IsRunning()
        {
            return Running;
        }

        public void ChangeRunState()
        {
            if (!Running)
            {
                if (StartOrResume())
                    Running = true;
            }
            else
            {
                if (Pause())
                    Running = false;
            }
        }

        public void Stop()
        {
            Timer.Dispose();
        }

        protected virtual bool StartOrResume()
        {
            return Timer.Change(0, PeriodTime);
        }

        protected virtual bool Pause()
        {
            return Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
