using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClickerHeroesClicker
{
    public static class External
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowDimension
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public const uint WM_LBUTTONDOWN = 0x201;
        public const uint WM_LBUTTONUP = 0x202;
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x0101;
        public const uint FIRST_NUMBER = 0x30;
        public const uint Z_KEY = 0x5A;

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hWnd, out WindowDimension lpRect);
    }
}
