using System;
using System.Runtime.InteropServices;

namespace ClickerHeroesClicker.StaticMembers
{
    public static class External
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowDimension
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public const uint WM_LBUTTONDOWN = 0x201;
        public const uint WM_LBUTTONUP = 0x202;
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x0101;
        public const uint FIRST_NUMBER = 0x30;
        public const uint Z_KEY = 0x5A;
        public const uint PW_CLIENTONLY = 0x1;

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out External.WindowDimension lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

    }
}
