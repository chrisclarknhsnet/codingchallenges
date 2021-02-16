using LookBeforeYouLeap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class LeapYearCalculatorTests
    {
        ILeapYearCalculator _calculator;

        [TestInitialize]
        public void Initialise()
        {
            _calculator = new LeapYearCalculator();
        }

        [TestMethod]
        public void IsLeapYear_When_Not_Divisible_By_4_Returns_False()
        {
            // Arrange
            var year = 1993;

            // Act
            var result = _calculator.IsLeapYear(year);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLeapYear_When_Divisible_By_4_Returns_True()
        {
            // Arrange
            var year = 1996;

            // Act
            var result = _calculator.IsLeapYear(year);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLeapYear_When_Divisible_By_100_Returns_False()
        {
            // Arrange
            var year = 1900;

            // Act
            var result = _calculator.IsLeapYear(year);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLeapYear_When_Divisible_By_400_Returns_True()
        {
            // Arrange
            var year = 2000;

            // Act
            var result = _calculator.IsLeapYear(year);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
