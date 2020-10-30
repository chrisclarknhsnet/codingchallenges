using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace YouPutAHexOnMe
{
    /// <summary>
    /// 48 minutes using strict test first methodology, time includes VS project set up.
    /// 
    /// Note: Needed to Google C# exponential operator as mistakenly was using the ^ bit wise operator.
    /// </summary>
    public class Convertor : IConvertor
    {
        private IDictionary<char, int> _hexToDecConversionValues = new Dictionary<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 }
        };

        public int ConvertHexadecimalToDecimal(string hexadecimalValue)
        {
            var hexRegEx = new Regex("^[0-9ABCDEF]+$");

            if (!hexRegEx.IsMatch(hexadecimalValue))
            {
                throw new ArgumentOutOfRangeException("Only valid hexadecimal numbers are allowed");
            }

            int result = 0;

            for (int i = hexadecimalValue.Length - 1; i >= 0; i--)  // Right to left processing
            {

                var adjuster = Convert.ToInt32(Math.Pow(16, (hexadecimalValue.Length - 1 - i)));
                var nonPositionAdjustedValue = _hexToDecConversionValues[hexadecimalValue[i]];
                var positionAdjustedValue = adjuster * nonPositionAdjustedValue;
                result += positionAdjustedValue;
            }

            return result;
        }
    }
}
