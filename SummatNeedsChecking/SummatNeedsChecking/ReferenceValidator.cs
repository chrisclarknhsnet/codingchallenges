using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace SummatNeedsChecking
{
    public class ReferenceValidator : IReferenceValidator
    {
        private const string cFORMAT_REGEX = @"^([A-Z]|[a-z]]){1}([A-Z]|[a-z]|[0-9]){5}\d{2}$";

        public bool Validate(string reference)
        {
            if (reference == null)
            {
                throw new NullReferenceException();
            }

            // Simple format validation
            if (!Regex.IsMatch(reference, cFORMAT_REGEX))
            {
                return false;
            }

            // If all ok calculate checksum
            var first6charssum = reference.Substring(0, 6).Sum(c => (int)c);
            var checksum = first6charssum % 100;
            var checksumAsString = checksum.ToString().PadLeft(2, '0');

            return reference.EndsWith(checksumAsString);
        }
    }
}
