using System.Text.RegularExpressions;

namespace ApprenticeTechTest2021
{
    public class NHSNumberValidator : INHSNumberValidator
    {
        private const string cREGEX_VALID_NUMBER = @"^[1-9]{1}\d{9}$";

        private IChecksumCalculator _calculator;

        public NHSNumberValidator(IChecksumCalculator calculator)
        {
            _calculator = calculator;
        }

        public bool IsValid(string nhsNumber)
        {
            if (string.IsNullOrWhiteSpace(nhsNumber))
            {
                return false;
            }

            if (!Regex.IsMatch(nhsNumber, cREGEX_VALID_NUMBER))
            {
                return false;
            }

            // Find checksum
            var checksum = _calculator.CalculateCheckSum(nhsNumber);

            if (!nhsNumber.EndsWith(checksum.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}
