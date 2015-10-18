using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads
{
    public abstract class Worker
    {
        protected Timer Timer;
        protected int PeriodTime;
        protected IntPtr _hwnd;
        private bool Running;

        public Worker(IntPtr hwnd, int periodTime)
        { 
            _hwnd = hwnd;
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
            Timer.Dispose();
        }

        private void StartOrResume()
        {
            Timer.Change(0, PeriodTime);
        }

        private void Pause()
        {
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
