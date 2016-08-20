using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class Abilities : Worker
    {
        private Timer backgroundCounterTimer;

        private volatile int[] AbilitiesCooldown = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int LastAbilityUsed = -1;

        public Abilities(IntPtr hwnd) : base(hwnd, 10050)
        {
            backgroundCounterTimer = new Timer(new TimerCallback(BackgroundRun), null, 0, 1000);
        }

        private void BackgroundRun(object obj)
        {
            for (int i = 0; i < this.AbilitiesCooldown.Length; i++)
            {
                if (this.AbilitiesCooldown[i] > 0)
                    this.AbilitiesCooldown[i] -= 1;
            }
        }

        protected override void Run(object args)
        {
            if (this.IsKeyReady(6) /*120*/ && this.IsKeyReady(9) /*15*/)
            {
                this.SendKey(6); //120
                this.SendKey(9); //15
            }

            if (this.IsKeyReady(8) /*15*/ && this.IsKeyReady(3) /*7.30*/ && this.IsKeyReady(1) /*2.30*/)
            {
                this.SendKey(7); //15
                this.SendKey(5); //15
                this.SendKey(8); //15

                this.SendKey(3); //7.30
                this.SendKey(4); //7.30

                this.SendKey(1); //2.30
                this.SendKey(2); //2.30
            }
            else if (IsKeyReady(3) /*7.30*/ && IsKeyReady(1) /*2.30*/)
            {
                this.SendKey(3); //7.30
                this.SendKey(4); //7.30

                this.SendKey(1); //2.30
                this.SendKey(2); //2.30
            }
            else if (IsKeyReady(1) /*2.30*/)
            {
                this.SendKey(1); //2.30
                this.SendKey(2); //2.30
            }
        }

        private bool IsKeyReady(int index)
        {
            if (index >= 1 && index <= 9)
            {
                return this.AbilitiesCooldown[index-1] <= 0;
            }
            return false;
        }

        private void SendKey(int index)
        {
            if (index >= 1 && index <= 9)
            {
                Win32API.PostMessage(this.Hwnd, Win32API.WM_KEYDOWN, (IntPtr)(Win32API.FIRST_NUMBER + index), IntPtr.Zero);
                this.SetCooldown(index);
            }
        }

        private void SetCooldown(int index)
        {
            this.AbilitiesCooldown[index-1] = Values.AbilitiesTimeouts[index-1];
            if (index == 9 && this.LastAbilityUsed != -1)
            {
                this.AbilitiesCooldown[this.LastAbilityUsed -1] -= Values.CooldownReduction;
            }
            else
            {
                this.LastAbilityUsed = index;
            }
        }
    }
}
