using ClickerHeroesClicker.Modules.Menu;
using ClickerHeroesClicker.Modules.Threads;
using ClickerHeroesClicker.Shared;
using System;

namespace ClickerHeroesClicker
{
    class ClickerMain
    {
        static void Main(string[] args)
        {
            IntPtr hwnd = Win32API.FindWindow(null, "Clicker Heroes");
            if (hwnd == IntPtr.Zero)
            {
                Console.WriteLine("Error al trobar la finestra de Clicker Heroes. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            WorkerContainer.Create(hwnd);
            Menu.ShowOptionsWaiter();
            WorkerContainer.Stop();

            Environment.Exit(Environment.ExitCode);
        }
    }
}
