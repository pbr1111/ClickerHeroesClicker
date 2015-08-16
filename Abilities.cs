using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClickerHeroesClicker
{
    public static class Abilities
    {
        private static int[] Abs = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private static readonly int[] Timeouts = 
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

        public static void run(IntPtr hwnd)
        {
            while (true)
            {
                for (int i = 0; i < Abs.Length; i++)
                {
                    if (Abs[i] > 0)
                        Abs[i] -= 10;
                }

                if (IsKeyReady(6) /*120*/)
                {
                    SendKey(hwnd, 6);
                }

                if (IsKeyReady(8) /*15*/ && IsKeyReady(3) /*7.30*/ && IsKeyReady(1) /*2.30*/)
                {
                    SendKey(hwnd, 7); //15
                    SendKey(hwnd, 5); //15
                    SendKey(hwnd, 8); //15

                    SendKey(hwnd, 3); //7.30
                    SendKey(hwnd, 4); //7.30

                    SendKey(hwnd, 1); //2.30
                    SendKey(hwnd, 2); //2.30

                }
                else if (IsKeyReady(3) /*7.30*/ && IsKeyReady(1))
                {
                    SendKey(hwnd, 3); //7.30
                    SendKey(hwnd, 4); //7.30

                    SendKey(hwnd, 1); //2.30
                    SendKey(hwnd, 2); //2.30
                }
                else if (IsKeyReady(1))
                {
                    SendKey(hwnd, 1); //2.30
                    SendKey(hwnd, 2); //2.30
                }
                Thread.Sleep(10050);
            }
        }

        private static bool IsKeyReady(int index)
        {
            if (index >= 1 && index <= 9)
            {
                return Abs[index] <= 0;
            }
            return false;
        }

        private static void SetKeyTimeout(int index)
        {
            if (index >= 1 && index <= 9 && Abs[index] <= 0)
            {
                Abs[index] = Timeouts[index];
            }
        }

        private static void SendKey(IntPtr hwnd, int index)
        {
            if (index >= 1 && index <= 9)
            {
                External.PostMessage(hwnd, External.WM_KEYDOWN, (IntPtr)(External.FIRST_NUMBER + index), IntPtr.Zero);
                Abilities.SetKeyTimeout(index);
            }
        }
    }
}
