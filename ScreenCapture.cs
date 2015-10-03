using ClickerHeroesClicker.StaticMembers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ClickerHeroesClicker
{
    public class ScreenCapture
    {
        private Rectangle bounds;
        private IntPtr hwnd;

        public ScreenCapture(IntPtr hwnd, External.WindowDimension rc)
        {
            this.hwnd = hwnd;
            this.bounds = new Rectangle(rc.Left, rc.Top, rc.Right - rc.Left, rc.Bottom - rc.Top);
        }
       
        private Bitmap CaptureWindow()
        {
            Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics gfxBmp = Graphics.FromImage(bmp))
            {
                IntPtr hdcBitmap = gfxBmp.GetHdc();
                try
                {
                    External.PrintWindow(hwnd, hdcBitmap, External.PW_CLIENTONLY);
                }
                finally
                {
                    gfxBmp.ReleaseHdc(hdcBitmap);
                }
            }
            return bmp;
        }

        public int GetColorsCapture()
        {
            int num = 0;
            int clickableId = -1;
            using (Bitmap bmp = CaptureWindow())
            {
                List<Color> colors = new List<Color>();
                for (int i = 0; i < Positions.Clickables.Length / 2; i++)
                {
                    colors.Add(bmp.GetPixel(Positions.Clickables[i, 0], Positions.Clickables[i, 1]));
                }
                foreach(Color i in colors)
                {
                    if(i.R >= 220 && i.R <= 260
                        && i.G >= 200 && i.G <= 240
                        && i.B < 30)
                    {
                        num++;
                        clickableId = colors.IndexOf(i);
                    }
                }
                if(num > 1)
                {
                    throw new Exception("No poden haver més 1 clickable al mateix temps.");
                }

                /*for (int i = 0; i < Positions.Clickables.Length / 2; i++)
                {
                    bmp.SetPixel(Positions.Clickables[i, 0], Positions.Clickables[i, 1], Color.Red);
                }*/

                if (clickableId != -1)
                {
                    string logPath = @"C:\Users\Pol\Desktop\clickerlog\";
                    string hourStr = DateTime.Now.ToString("HH_mm_ss");
                    bmp.SetPixel(Positions.Clickables[clickableId, 0], Positions.Clickables[clickableId, 1], Color.Red);
                    bmp.Save(logPath + @"\img\img_" + hourStr + ".png", ImageFormat.Png);

                    using (StreamWriter outputFile = new StreamWriter(logPath + @"\positions.txt", true))
                    {
                        outputFile.WriteLine("{0} - ClickableId: {1}, X: {2}, Y: {3}, Color: rgb({4}, {5}, {6})",
                            hourStr,
                            clickableId, 
                            Positions.Clickables[clickableId, 0], 
                            Positions.Clickables[clickableId, 1], 
                            colors[clickableId].R,
                            colors[clickableId].G,
                            colors[clickableId].B);
                    }
                }
            }
            return clickableId;
        }

    }
}
