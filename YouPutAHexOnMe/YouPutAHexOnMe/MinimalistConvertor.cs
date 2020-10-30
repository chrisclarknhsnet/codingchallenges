using System;
using System.Collections.Generic;
using System.Linq;

namespace YouPutAHexOnMe
{
    public class MinimalistConvertor : IConvertor
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
            try
            {
                return hexadecimalValue
                    .Select((c, i) => _hexToDecConversionValues[c] * (int) Math.Pow(16, hexadecimalValue.Length - i - 1))
                    .Sum();
            }
            catch
            {
                throw new ArgumentOutOfRangeException($"{hexadecimalValue} is not a valid hex value");
            }
        }

    }
}
