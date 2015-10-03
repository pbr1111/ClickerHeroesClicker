using System.Drawing;

namespace ClickerHeroesClicker.Shared
{
    public static class Values
    {
        public static readonly int[,] Clickables =
        {
            { 515, 460 }, 
            { 740, 400 }, 
            { 755, 445 }, 
            { 750, 350 }, 
            { 860, 480 }, 
            { 1000, 425 },
            { 1040, 410 } 
        };

        public static Color ClickableColor = Color.FromArgb(242, 201, 0);

        public static class ComboMantainer
        {
            public const int X = 890;
            public const int Y = 450;
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
    }
}
