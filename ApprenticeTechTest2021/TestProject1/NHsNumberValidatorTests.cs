using ApprenticeTechTest2021;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProject1
{
    [TestClass]
    public class NHsNumberValidatorTests
    {
        private const string cVALID_NHS_NUMBER = "1111111111";

        private INHSNumberValidator _validator;
        private Mock<IChecksumCalculator> _mockCalculator;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockCalculator = new Mock<IChecksumCalculator>();
            _mockCalculator.Setup(m => m.CalculateCheckSum(It.IsAny<string>())).Returns(1);
            _validator = new NHSNumberValidator(_mockCalculator.Object);
        }

        #region Test methods

        [TestMethod]
        public void Validate_When_Valid_Returns_True()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER;

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Validate_When_Length_More_Than_10_Characters_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER + "1";

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Length_Less_Than_10_Characters_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER.Substring(0, 9);

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Validate_When_Null_Returns_False()
        {
            // Arrange
            string nhsNo = null;

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Blank_Returns_False()
        {
            // Arrange
            var nhsNo = "          ";   // 10 spaces

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Starts_With_Zero_Returns_False()
        {
            // Arrange
            var nhsNo = "0" + cVALID_NHS_NUMBER.Substring(0, 9);

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Contains_Letters_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER.Substring(0, 9) + "X";

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Contains_Special_Characters_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER.Substring(0, 4) + "-" + cVALID_NHS_NUMBER.Substring(4, 5);

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Has_Leading_Spaces_Returns_False()
        {
            // Arrange
            var nhsNo = " " + cVALID_NHS_NUMBER;

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Has_Trailing_Spaces_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER + " ";

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Contains_Spaces_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER.Substring(0,4) + " " + cVALID_NHS_NUMBER.Substring(4,5);

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_When_Does_Not_End_In_Checksum_Returns_False()
        {
            // Arrange
            var nhsNo = cVALID_NHS_NUMBER;  // Ends in 1
            _mockCalculator.Setup(m => m.CalculateCheckSum(nhsNo)).Returns(9);

            // Act
            var result = _validator.IsValid(nhsNo);

            //Assert
            Assert.IsFalse(result);
        }

        #endregion
    }
}
