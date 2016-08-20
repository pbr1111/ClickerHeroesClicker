using System.Drawing;

namespace ClickerHeroesClicker.Shared
{
    public static class Values
    {
        public static readonly int[,] Clickables =
        {
            { 523, 451 },
            { 746, 395 },
            { 759, 343 },
            { 872, 475 },
            { 1004, 416 },
            { 1052, 406 }
        };

        public static Color ClickableColor = Color.FromArgb(234, 76, 10);
        public static Color FarmModeInactiveColor = Color.FromArgb(255, 0, 0);

        public static class ComboMantainer
        {
            public const int X = 1080;
            public const int Y = 400;
        }

        public static class UpgradeHeroe
        {
            public const int X = 100;
            public const int Y = 395;
        }

        public static class Scroll
        {
            public const int X = 546;
            public const int DownY = 623;
            public const int UpY = 189;
        }

        public static class FarmMode
        {
            public const int X = 1115;
            public const int Y = 250;
        }

        public static readonly int[] AbilitiesTimeouts =
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

        public const int CooldownReduction = 60 * 60;
    }
}
