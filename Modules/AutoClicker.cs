using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClickerHeroesClicker.Modules
{
    public class AutoClicker : Worker
    {
        public AutoClicker(IntPtr hwnd)
        {
            _hwnd = hwnd;
            _thread = new Thread(Run);
        }

        private void Run()
        {
            while (true)
            {
                wh.WaitOne();

                Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                Shared.SendMouseLeft(_hwnd, Positions.ComboMantainer.X, Positions.ComboMantainer.Y);
                Thread.Sleep(100);
            }
        }



    }
}
