using System.Drawing;

namespace ClickerHeroesClicker.Shared
{
    public static class Values
    {
        public static readonly int[,] Clickables =
        {
            { 515, 460 }, //rgb(253, 226, 8)
            { 740, 400 }, //rgb(251, 223, 24)
            { 755, 445 }, //rgb(255, 207, 8)
            { 750, 350 }, //rgb(234, 217, 13)
            { 860, 480 }, //rgb(253, 201, 4)
            { 1000, 425 }, //rgb(242, 201, 0)
            { 1040, 410 } //rgb(242, 158, 0)
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
