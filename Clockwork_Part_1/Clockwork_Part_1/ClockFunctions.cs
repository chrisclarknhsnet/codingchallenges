using Clockwork_Drivers_Part1;
using System;

namespace Clockwork_Part_1
{
    public class ClockFunctions
    {
        private ILedClockDriver _driver;

        public ClockFunctions(ILedClockDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Show the input date on the held Led clock driver interface
        /// </summary>
        /// <param name="timeToShow">The time to show</param>
        public void showTime(DateTime timeToShow)
        {
            // Work out what minutes position should be
            var posn_Minutes = timeToShow.Minute;

            // Work out what whole hour position is
            var hours = timeToShow.Hour % 12;
            var posn_Hours = hours * 5;         // 5 ticks/leds per hour

            // Work out how may ticks past the hour it should be 1 tick = 12 minutes (round down any result to nearest tick)
            posn_Hours += timeToShow.Minute / 12;

            // Show time via the driver (bright = minutes)
            _driver.showLed(posn_Minutes, true);

            if (posn_Minutes != posn_Hours)
            {
                _driver.showLed(posn_Hours, false);
            }
        }
    }
}
