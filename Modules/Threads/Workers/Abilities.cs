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
            for (int i = 0; i < AbilitiesCooldown.Length; i++)
            {
                if (AbilitiesCooldown[i] > 0)
                    AbilitiesCooldown[i] -= 1;
            }
        }

        protected override void Run(object args)
        {
            if (IsKeyReady(6) /*120*/ && IsKeyReady(9) /*15*/)
            {
                SendKey(6); //120
                SendKey(9); //15
            }

            if (IsKeyReady(8) /*15*/ && IsKeyReady(3) /*7.30*/ && IsKeyReady(1) /*2.30*/)
            {
                SendKey(7); //15
                SendKey(5); //15
                SendKey(8); //15

                SendKey(3); //7.30
                SendKey(4); //7.30

                SendKey(1); //2.30
                SendKey(2); //2.30
            }
            else if (IsKeyReady(3) /*7.30*/ && IsKeyReady(1) /*2.30*/)
            {
                SendKey(3); //7.30
                SendKey(4); //7.30

                SendKey(1); //2.30
                SendKey(2); //2.30
            }
            else if (IsKeyReady(1) /*2.30*/)
            {
                SendKey(1); //2.30
                SendKey(2); //2.30
            }
        }

        private bool IsKeyReady(int index)
        {
            if (index >= 1 && index <= 9)
            {
                return AbilitiesCooldown[index-1] <= 0;
            }
            return false;
        }

        private void SendKey(int index)
        {
            if (index >= 1 && index <= 9)
            {
                Win32API.PostMessage(_hwnd, Win32API.WM_KEYDOWN, (IntPtr)(Win32API.FIRST_NUMBER + index), IntPtr.Zero);
                SetCooldown(index);
            }
        }

        private void SetCooldown(int index)
        {
            AbilitiesCooldown[index-1] = Values.AbilitiesTimeouts[index-1];
            if (index == 9 && LastAbilityUsed != -1)
            {
                AbilitiesCooldown[LastAbilityUsed-1] -= 60;
            }
            else
            {
                LastAbilityUsed = index;
            }
        }
    }
}
