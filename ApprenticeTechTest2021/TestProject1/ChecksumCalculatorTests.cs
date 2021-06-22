using ApprenticeTechTest2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class ChecksumCalculatorTests
    {
        IChecksumCalculator _calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _calculator = new ChecksumCalculator();
        }

        #region Test methods

        [TestMethod]
        public void CalculateChecksum_Returns_Correct_Value_Example_1()
        {
            // Arrange
            // 1111111111 should return checksum of 1
            var nhsNumber = "1111111111";

            // Act
            var result = _calculator.CalculateCheckSum(nhsNumber);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CalculateChecksum_Returns_Correct_Value_Example_2()
        {
            // Arrange
            // 4010232137 should return checksum of 7
            var nhsNumber = "4010232137";

            // Act
            var result = _calculator.CalculateCheckSum(nhsNumber);

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void CalculateChecksum_Returns_Correct_Value_Example_3()
        {
            // Arrange
            // 5034577891 should return checksum of 5
            var nhsNumber = "5034577891";

            // Act
            var result = _calculator.CalculateCheckSum(nhsNumber);

            // Assert
            Assert.AreEqual(5, result);
        }

        #endregion
    }
}
