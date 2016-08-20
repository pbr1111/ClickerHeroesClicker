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
            this.Hwnd = hwnd;
            this.Timer = new Timer(new TimerCallback(Run));
            this.PeriodTime = periodTime;
            this.Running = false;
        }

        protected abstract void Run(object args);

        public bool IsRunning()
        {
            return this.Running;
        }

        public void ChangeRunState()
        {
            if (!this.Running)
            {
                if (this.StartOrResume())
                    this.Running = true;
            }
            else
            {
                if (this.Pause())
                    this.Running = false;
            }
        }

        public void Stop()
        {
            this.Timer.Dispose();
        }

        protected virtual bool StartOrResume()
        {
            return this.Timer.Change(0, this.PeriodTime);
        }

        protected virtual bool Pause()
        {
            return this.Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
