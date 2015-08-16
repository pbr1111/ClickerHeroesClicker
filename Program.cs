using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ClickerHeroesClicker
{
    class Program
    {
        static IntPtr hwnd;
        static void Main(string[] args)
        {
            hwnd = GetClickerWindow();
            if (hwnd == null)
            {
                Console.WriteLine("Error al trobar la finestra de Clicker Heroes. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            External.WindowDimension rc;
            External.GetWindowRect(hwnd, out rc);

            if (rc.top < 0)
            {
                Console.WriteLine("El Clicker Heroes no ha d'estar minimitzat. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            Thread abilitiesThread = new Thread(() => Abilities.run(hwnd));
            abilitiesThread.Start();

            //Scroll
            /*PressMouseLeft(hwnd, Positions.Scroll.X, Positions.Scroll.DownY);
            Thread.Sleep(2000);
            HoldMouseLeft(hwnd);*/

            while (true)
            {
                // Click 2 cops als monstres cada 5s
                /*SendMouseLeft(Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                SendMouseLeft(Positions.ComboMantainer.X, Positions.ComboMantainer.Y);*/

                ClickClickables();

                PressZKey();
                SendMouseLeft(Positions.UpgradeHeroe.X, Positions.UpgradeHeroe.Y);
                HoldZKey();

                Thread.Sleep(5000);
            }
        }

        private static void ClickClickables()
        {
            for(int i = 0; i < Positions.Clickables.Length/2; i++)
            {
                SendMouseLeft(Positions.Clickables[i, 0], Positions.Clickables[i, 1]);
            }
        }

        private static IntPtr GetClickerWindow()
        {
            return (IntPtr)External.FindWindow(null, "Clicker Heroes");
        }

        private static void SendMouseLeft(int x, int y)
        {
            int coordinates = x | (y << 16);
            External.PostMessage(hwnd, External.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
            External.PostMessage(hwnd, External.WM_LBUTTONUP, (IntPtr)0x1, (IntPtr)coordinates);
        }

        private static void PressMouseLeft(int x, int y)
        {
            int coordinates = x | (y << 16);
            External.PostMessage(hwnd, External.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
        }

        private static void HoldMouseLeft()
        {
            External.PostMessage(hwnd, External.WM_LBUTTONUP, (IntPtr)0x1, IntPtr.Zero);
        }

        private static void PressZKey()
        {
            External.PostMessage(hwnd, External.WM_KEYDOWN, (IntPtr)External.Z_KEY, (IntPtr)0x2c0001);
        }

        private static void HoldZKey()
        {
            External.PostMessage(hwnd, External.WM_KEYUP, (IntPtr)External.Z_KEY, IntPtr.Zero);
        }
    }
}
