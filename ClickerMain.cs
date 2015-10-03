using ClickerHeroesClicker.Modules;
using ClickerHeroesClicker.Shared;
using System;

namespace ClickerHeroesClicker
{
    class ClickerMain
    {
        private static IntPtr hwnd;

        static void Main(string[] args)
        {
            hwnd = GetClickerWindow();
            if (hwnd == null)
            {
                Console.WriteLine("Error al trobar la finestra de Clicker Heroes. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            Win32API.WindowDimension rc = new Win32API.WindowDimension();
            Win32API.GetClientRect(hwnd, out rc);
            if (rc.Bottom == 0)
            {
                Console.WriteLine("La finestra no ha d'estar minimitzada. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            WorkerContainer.Create(hwnd, rc);
            Menu.ShowOptionsWaiter();
            WorkerContainer.Stop();

            Environment.Exit(Environment.ExitCode);
        }

        private static IntPtr GetClickerWindow()
        {
            return (IntPtr)Win32API.FindWindow(null, "Clicker Heroes");
        }

    }
}
