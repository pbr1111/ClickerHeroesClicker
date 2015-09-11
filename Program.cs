using ClickerHeroesClicker.Modules;
using System;
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

            bool[] options = { false, false, false, false };
            ShowOptions(options);

            Worker abilitiesThread = new Abilities(hwnd);
            Worker upgradeHeroesThread = new UpgradeHeroes(hwnd);
            Worker clickScreenThread = new ClickClickables(hwnd);
            Worker autoClickerThread = new AutoClicker(hwnd);

            ConsoleKey pressed;
            while ((pressed = Console.ReadKey(true).Key) != ConsoleKey.Escape)
            {
                switch (pressed)
                {
                    case ConsoleKey.F1:
                        options[0] = !options[0];
                        if (options[0])
                            abilitiesThread.StartOrResume();
                        else
                            abilitiesThread.Pause();
                        ShowOptions(options);
                        break;
                    case ConsoleKey.F2:
                        options[1] = !options[1];
                        if (options[1])
                            upgradeHeroesThread.StartOrResume();
                        else
                            upgradeHeroesThread.Pause();
                        ShowOptions(options);
                        break;
                    case ConsoleKey.F3:
                        options[2] = !options[2];
                        if (options[2])
                            clickScreenThread.StartOrResume();
                        else
                            clickScreenThread.Pause();
                        ShowOptions(options);
                        break;
                    case ConsoleKey.F4:
                        options[3] = !options[3];
                        if (options[3])
                            autoClickerThread.StartOrResume();
                        else
                            autoClickerThread.Pause();
                        ShowOptions(options);
                        break;
                    default:
                        break;
                }
            }

            // ESC pressed --> stop all alive threads
            abilitiesThread.Stop();
            upgradeHeroesThread.Stop();
            clickScreenThread.Stop();
            autoClickerThread.Stop();

            // Force quit
            Environment.Exit(Environment.ExitCode);
        }


        //Scroll
        /*PressMouseLeft(hwnd, Positions.Scroll.X, Positions.Scroll.DownY);
        Thread.Sleep(2000);
        ReleaseMouseLeft(hwnd);
        // Click 2 cops als monstres cada 5s
        SendMouseLeft(Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
        SendMouseLeft(Positions.ComboMantainer.X, Positions.ComboMantainer.Y);*/

        private static void ShowOptions(bool[] options)
        {
            Console.Clear();
            Console.WriteLine("Opcions:");
            Console.WriteLine("\tF1 - " + GetTextNextStateOption(options[0]) + " utilitzar habilitats.");
            Console.WriteLine("\tF2 - " + GetTextNextStateOption(options[1]) + " pujar heroi fixe x25.");
            Console.WriteLine("\tF3 - " + GetTextNextStateOption(options[2]) + " clicar als clicables.");
            Console.WriteLine("\tF4 - " + GetTextNextStateOption(options[3]) + " l'autoclicker.");
            Console.WriteLine("ESC per sortir");
        }

        private static string GetTextNextStateOption(bool optionState)
        {
            return optionState ? "Desactivar" : "Activar";
        }

        private static IntPtr GetClickerWindow()
        {
            return (IntPtr)External.FindWindow(null, "Clicker Heroes");
        }

        /*private static void PressMouseLeft(int x, int y)
        {
            int coordinates = x | (y << 16);
            External.PostMessage(hwnd, External.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
        }

        private static void ReleaseMouseLeft()
        {
            External.PostMessage(hwnd, External.WM_LBUTTONUP, (IntPtr)0x1, IntPtr.Zero);
        }*/

    }
}
