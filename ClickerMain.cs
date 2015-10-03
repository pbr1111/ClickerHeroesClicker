using ClickerHeroesClicker.Modules;
using ClickerHeroesClicker.StaticMembers;
using System;

namespace ClickerHeroesClicker
{
    class ClickerMain
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

            External.WindowDimension rc = new External.WindowDimension();
            External.GetClientRect(hwnd, out rc);

            if (rc.Bottom == 0)
            {
                Console.WriteLine("La finestra no ha d'estar minimitzada. Prem una tecla per continuar.");
                Console.ReadKey(true);
                return;
            }

            //IMG 
            /*ScreenCapture sc = new ScreenCapture(hwnd, rc);
            while (true)
            {
                var clickableId = sc.GetColorsCapture();
                if(clickableId != -1)
                {
                    Shared.SendMouseLeft(hwnd, Positions.Clickables[clickableId, 0], Positions.Clickables[clickableId, 1]);
                }
                Thread.Sleep(1000);
            }
            return;*/

            Worker abilitiesThread = new Abilities(hwnd);
            Worker upgradeHeroesThread = new UpgradeHeroes(hwnd);
            Worker clickScreenThread = new ClickClickables(hwnd);
            AutoClicker autoClickerThread = new AutoClicker(hwnd);

            bool[] options = { false, false, false, false };
            int intensity = autoClickerThread.GetMinIntensity();
            ShowOptions(options, intensity);

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
                        break;
                    case ConsoleKey.F2:
                        options[1] = !options[1];
                        if (options[1])
                            upgradeHeroesThread.StartOrResume();
                        else
                            upgradeHeroesThread.Pause();
                        break;
                    case ConsoleKey.F3:
                        options[2] = !options[2];
                        if (options[2])
                            clickScreenThread.StartOrResume();
                        else
                            clickScreenThread.Pause();
                        break;
                    case ConsoleKey.F4:
                        options[3] = !options[3];
                        if (options[3])
                            autoClickerThread.StartOrResume();
                        else
                            autoClickerThread.Pause();
                        break;
                    case ConsoleKey.UpArrow:
                        intensity = autoClickerThread.UpIntensity();
                        break;
                    case ConsoleKey.DownArrow:
                        intensity = autoClickerThread.DownIntensity();
                        break;
                    default:
                        break;
                }
                ShowOptions(options, intensity);
            }

            // ESC pressed --> stop all alive threads
            abilitiesThread.Stop();
            upgradeHeroesThread.Stop();
            clickScreenThread.Stop();
            autoClickerThread.Stop();

            // Force quit
            Environment.Exit(Environment.ExitCode);
        }

        private static void ShowOptions(bool[] options, int intensity)
        {
            Console.Clear();
            Console.WriteLine("Opcions:");
            Console.WriteLine("\tF1 - " + GetTextNextStateOption(options[0]) + " utilitzar habilitats.");
            Console.WriteLine("\tF2 - " + GetTextNextStateOption(options[1]) + " pujar heroi fixe x25.");
            Console.WriteLine("\tF3 - " + GetTextNextStateOption(options[2]) + " clicar als clicables.");
            Console.WriteLine("\tF4 - " + GetTextNextStateOption(options[3]) + " l'autoclicker. Nivell: " + intensity + " (amunt/avall).");
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

    }
}
