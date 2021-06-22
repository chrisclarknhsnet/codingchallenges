using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApprenticeTechTest2021
{
    public class ChecksumCalculator : IChecksumCalculator
    {
        public int CalculateCheckSum(string nhsNumber)
        {
            var total = 0;

            for (int i = 0; i < 9; i++) // First 9 digits only
            {
                var multiplier = 10 - i;
                var value = Convert.ToInt32(nhsNumber.Substring(i, 1));
                total +=  value * multiplier;
            }

            var remainder = total % 11;
            return remainder == 0 ? 0 : 11 - remainder;
        }
    }
}
