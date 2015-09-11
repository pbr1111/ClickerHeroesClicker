using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroesClicker
{
    public static class Shared
    {
        public static void SendMouseLeft(IntPtr hwnd, int x, int y)
        {
            int coordinates = x | (y << 16);
            External.PostMessage(hwnd, External.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
            External.PostMessage(hwnd, External.WM_LBUTTONUP, (IntPtr)0x1, (IntPtr)coordinates);
        }
    }
}
