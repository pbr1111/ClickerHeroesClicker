using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroesClicker
{
    public static class Positions
    {
        public static readonly int[,] Clickables = 
        {
            { 515, 460 },
            { 740, 400 },
            { 755, 4450 },
            { 755, 340 },
            { 860, 480 },
            { 1000, 425 },
            { 1040, 410 }
        };

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
