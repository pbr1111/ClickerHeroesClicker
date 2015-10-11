using ClickerHeroesClicker.Modules;
using ClickerHeroesClicker.Shared;
using System;
using System.Drawing;

namespace ClickerHeroesClicker
{
    class ClickerMain
    {
        static void Main(string[] args)
        {
            IntPtr hwnd = Win32API.FindWindow(null, "Clicker Heroes");
            if (hwnd == null)
            {
                Console.WriteLine("Error al trobar la finestra de Clicker Heroes. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            Rectangle windowDimensions = Win32API.GetClientRect(hwnd);
            if (windowDimensions.Width == 0)
            {
                Console.WriteLine("La finestra no ha d'estar minimitzada. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            WorkerContainer.Create(hwnd, windowDimensions);
            Menu.ShowOptionsWaiter();
            WorkerContainer.Stop();

            Environment.Exit(Environment.ExitCode);
        }
    }

}
