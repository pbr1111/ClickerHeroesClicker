using System;

namespace ClickerHeroesClicker.Shared
{
    public static class Methods
    {
        public static void SendMouseLeft(IntPtr hwnd, int x, int y)
        {
            int coordinates = x | (y << 16);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONDOWN, IntPtr.Zero, (IntPtr)coordinates);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONUP, IntPtr.Zero, (IntPtr)coordinates);
        }

        public static void PressKey(IntPtr hwnd, uint key)
        {
            Win32API.PostMessage(hwnd, Win32API.WM_KEYDOWN, (IntPtr)key, (IntPtr)0x2c0001);
        }

        public static void ReleaseKey(IntPtr hwnd, uint key)
        {
            Win32API.PostMessage(hwnd, Win32API.WM_KEYUP, (IntPtr)key, IntPtr.Zero);
        }

        // Scroll usage
        /*Methods.PressMouseLeft(hwnd, Values.Scroll.X, Values.Scroll.UpY);
        Thread.Sleep(2000);
        Methods.ReleaseMouseLeft(hwnd, Values.Scroll.X, Values.Scroll.UpY);*/

        /*public static void PressMouseLeft(IntPtr hwnd, int x, int y)
        {
            int coordinates = x | (y << 16);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONDOWN, IntPtr.Zero, (IntPtr)coordinates);
        }

        public static void ReleaseMouseLeft(IntPtr hwnd, int x, int y)
        {
            int coordinates = x | (y << 16);
            Win32API.PostMessage(hwnd, Win32API.WM_LBUTTONUP, IntPtr.Zero, (IntPtr)coordinates);
        }*/
    }
}
