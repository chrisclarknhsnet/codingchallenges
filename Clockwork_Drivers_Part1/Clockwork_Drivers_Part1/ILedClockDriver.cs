namespace Clockwork_Drivers_Part1
{
    public interface ILedClockDriver
    {
        ///<summary>
        /// position must be between 0 and 59 otherwise an
        /// InvalidArgumentException will occur
        ///
        /// Currently there can only be one bright and one normal
        /// LED showing.  Calling this method will automatically /// turn off the currently on bright or normal 
        /// LED
        ///
        /// In the event of multiple calls to this method with /// the same position the last call will take precedence /// i.e. bright would replace normal and normal would 
        /// replace bright
        ///</summary>
        void showLed(int position, bool isBright);
    }
}
