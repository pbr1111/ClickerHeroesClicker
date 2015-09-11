using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClickerHeroesClicker.Modules
{
    public class ClickClickables : Worker
    {
        public ClickClickables(IntPtr hwnd)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                ClickClickablePositions();
                Thread.Sleep(5000);
            }
        }


        private void ClickClickablePositions()
        {
            for (int i = 0; i < Positions.Clickables.Length / 2; i++)
            {
                Shared.SendMouseLeft(_hwnd, Positions.Clickables[i, 0], Positions.Clickables[i, 1]);
            }
        }
    }
}
