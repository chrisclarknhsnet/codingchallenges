using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummatNeedsChecking;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ReferenceValidatorTests
    {
        IReferenceValidator _validator;

        [TestInitialize]
        public void TestInitialize()
        {
            _validator = new ReferenceValidator();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Validate_When_Null_Throws_Exception()
        {
            // Arrange
            string reference = null;

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.Fail("Expected exception to be thrown");
        }

        [TestMethod]
        public void Validate_When_Reference_Ok_Returns_Valid()
        {
            // Arrange
            var prefix = "A00000";  // ASCII = 0 = 48, A = 65, therefore sum of prefix = 65 + (5 * 48) = 305, checksum = 05
            var reference = prefix + "05";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_When_Less_Than_8_Characters_Returns_Invalid()
        {
            // Arrange
            var reference = "T234567";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_More_Than_8_Characters_Returns_Invalid()
        {
            // Arrange
            var reference = "T23456789";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_First_Character_Not_Letter_Returns_Invalid()
        {
            // Arrange
            var reference = "12345678";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Non_Alpha_Numeric_Characters_Returns_Invalid()
        {
            // Arrange
            var reference = "T23 5678";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Last_Character_Not_Digit_Returns_Invalid()
        {
            // Arrange
            var reference = "T234567A";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Penultimate_Character_Not_Digit_Returns_Invalid()
        {
            // Arrange
            var reference = "T234567T8";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Checksum_Worng_Returns_Invalid()
        {
            // Arrange
            var prefix = "A00000";  // ASCII = 0 = 48, A = 65, therefore sum of prefix = 65 + (5 * 48) = 305, checksum = 05
            var reference = prefix + "06";

            // Act
            var result = _validator.Validate(reference);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
