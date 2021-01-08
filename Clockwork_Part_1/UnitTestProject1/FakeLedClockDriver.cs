using Clockwork_Drivers_Part1;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    /// <summary>
    /// Example of Fake which could be used, but preference is to use Mock instead
    /// </summary>
    public class FakeLedClockDriver : ILedClockDriver
    {
        private int _brightPosn;
        private int _normalPosn;

        public void showLed(int position, bool isBright)
        {
            if (isBright)
            {
                _brightPosn = position;
            }
            else
            {
                _normalPosn = position;
            }
        }

        public int BrightPosition => _brightPosn;
        public int NormalPosition => _normalPosn;
    }
}
