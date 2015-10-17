using ClickerHeroesClicker.Shared;
using System;
using System.Threading;

namespace ClickerHeroesClicker.Modules.Threads.Workers
{
    public class Abilities : Worker
    {
        private Thread backgroundCounterThread;

        private int[] Abs = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private readonly int[] Timeouts =
        {
            2 * 60 + 30,
            2 * 60 + 30,
            7 * 60 + 30,
            7 * 60 + 30,
            15 * 60,
            2 * 60 * 60,
            15 * 60,
            15 * 60,
            15 * 60
        };

        public Abilities(IntPtr hwnd): base(hwnd)
        {
            _thread = new Thread(Run);
            backgroundCounterThread = new Thread(BackgroundRun);
            backgroundCounterThread.IsBackground = true;
            backgroundCounterThread.Start();
        }

        private void BackgroundRun()
        {
            while (true)
            {
                for (int i = 0; i < Abs.Length; i++)
                {
                    if (Abs[i] > 0)
                        Abs[i] -= 10;
                }
                Thread.Sleep(10000);
            }
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                if (IsKeyReady(6) /*120*/)
                {
                    SendKey(6);
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
                else if (IsKeyReady(3) /*7.30*/ && IsKeyReady(1))
                {
                    SendKey(3); //7.30
                    SendKey(4); //7.30

                    SendKey(1); //2.30
                    SendKey(2); //2.30
                }
                else if (IsKeyReady(1))
                {
                    SendKey(1); //2.30
                    SendKey(2); //2.30
                }
                Thread.Sleep(10050);
            }
        }

        private bool IsKeyReady(int index)
        {
            if (index >= 1 && index <= 9)
            {
                return Abs[index] <= 0;
            }
            return false;
        }

        private void SetKeyTimeout(int index)
        {
            if (index >= 1 && index <= 9 && Abs[index] <= 0)
            {
                Abs[index] = Timeouts[index];
            }
        }

        private void SendKey(int index)
        {
            if (index >= 1 && index <= 9)
            {
                Win32API.PostMessage(_hwnd, Win32API.WM_KEYDOWN, (IntPtr)(Win32API.FIRST_NUMBER + index), IntPtr.Zero);
                SetKeyTimeout(index);
            }
        }
    }
}
