﻿using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ClickerHeroesClicker.Shared
{
    public static class Win32API
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct WindowDimension
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public Rectangle AsRectangle
            {
                get
                {
                    return new Rectangle(Left, Top, Right - Left, Bottom - Top);
                }
            }
        }

        public const uint WM_LBUTTONDOWN = 0x201;
        public const uint WM_LBUTTONUP = 0x202;
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_KEYUP = 0x0101;
        public const uint FIRST_NUMBER = 0x30;
        public const uint VK_LBUTTON = 0x01;
        public const uint VK_CONTROL = 0x11;
        public const uint Q_KEY = 0x51;
        public const uint Z_KEY = 0x5A;
        public const uint PW_CLIENTONLY = 0x1;

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out Win32API.WindowDimension lpRect);

        public static Rectangle GetClientRect(IntPtr hwnd)
        {
            Win32API.WindowDimension lpRect;
            Win32API.GetClientRect(hwnd, out lpRect);
            return lpRect.AsRectangle;
        }
    }
}
