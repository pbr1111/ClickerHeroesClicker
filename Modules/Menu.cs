using ClickerHeroesClicker.Modules.Threads;
using System;

namespace ClickerHeroesClicker.Modules
{
    public static class Menu
    {
        private static bool[] options = { false, false, false, false, false };
        private static int intensity;

        public static void ShowOptionsWaiter()
        {
            intensity = WorkerContainer.AutoClickerThread.GetMinIntensity();

            ShowOptions(options, intensity);

            ConsoleKey pressed;
            while ((pressed = Console.ReadKey(true).Key) != ConsoleKey.Escape)
            {
                switch (pressed)
                {
                    case ConsoleKey.F1:
                        options[0] = !options[0];
                        WorkerContainer.AbilitiesThread.ChangeRunState(options[0]);
                        break;
                    case ConsoleKey.F2:
                        options[1] = !options[1];
                        WorkerContainer.UpgradeHeroesThread.ChangeRunState(options[1]);
                        break;
                    case ConsoleKey.F3:
                        options[2] = !options[2];
                        WorkerContainer.ClickScreenThread.ChangeRunState(options[2]);
                        break;
                    case ConsoleKey.F4:
                        options[3] = !options[3];
                        WorkerContainer.AutoClickerThread.ChangeRunState(options[3]);
                        break;
                    case ConsoleKey.F5:
                        options[4] = !options[4];
                        WorkerContainer.AscensionWaiterThread.ChangeRunState(options[4]);
                        break;
                    case ConsoleKey.UpArrow:
                        intensity = WorkerContainer.AutoClickerThread.UpIntensity();
                        break;
                    case ConsoleKey.DownArrow:
                        intensity = WorkerContainer.AutoClickerThread.DownIntensity();
                        break;
                    default:
                        break;
                }
                ShowOptions(options, intensity);
            }
        }

        private static void ShowOptions(bool[] options, int intensity)
        {
            Console.Clear();
            Console.WriteLine("Opcions:");
            Console.WriteLine("\tF1 - " + GetTextNextStateOption(options[0]) + " utilitzar habilitats.");
            Console.WriteLine("\tF2 - " + GetTextNextStateOption(options[1]) + " pujar heroi fixe x100.");
            Console.WriteLine("\tF3 - " + GetTextNextStateOption(options[2]) + " clicar als clicables.");
            Console.WriteLine("\tF4 - " + GetTextNextStateOption(options[3]) + " l'autoclicker. Nivell: " + intensity + " (amunt/avall).");
            Console.WriteLine("\tF5 - " + GetTextNextStateOption(options[4]) + " clicar clicables intel·ligent.");
            Console.WriteLine("ESC per sortir");
        }

        private static string GetTextNextStateOption(bool optionState)
        {
            return optionState ? "Desactivar" : "Activar";
        }

    }
}
