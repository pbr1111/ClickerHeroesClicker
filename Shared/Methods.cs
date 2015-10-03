using System;

namespace ClickerHeroesClicker.Shared
{
    public static class Methods
    {
        public static void SendMouseLeft(IntPtr hwnd, int x, int y)
        {
            int coordinates = x | (y << 16);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONUP, (IntPtr)0x1, (IntPtr)coordinates);
        }

        // Scroll usage
        /*PressMouseLeft(hwnd, Positions.Scroll.X, Positions.Scroll.DownY);
        Thread.Sleep(2000);
        ReleaseMouseLeft(hwnd);*/

        /*public static void PressMouseLeft(int x, int y)
        {
            int coordinates = x | (y << 16);
            External.PostMessage(hwnd, External.WM_LBUTTONDOWN, (IntPtr)0x1, (IntPtr)coordinates);
        }

        public static void ReleaseMouseLeft()
        {
            External.PostMessage(hwnd, External.WM_LBUTTONUP, (IntPtr)0x1, IntPtr.Zero);
        }*/
    }
}
