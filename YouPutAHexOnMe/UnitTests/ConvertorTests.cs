using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YouPutAHexOnMe;

namespace UnitTests
{
    [TestClass]
    public class ConvertorTests
    {
        private IConvertor _convertor;

        [TestInitialize]
        public void Initialise()
        {
            //_convertor = new Convertor();
            _convertor = new MinimalistConvertor();
        }

        [TestMethod]
        public void Convertor_When_Single_Digit()
        {
            // Arrange
            var val = "9";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Convertor_When_Single_Letter()
        {
            // Arrange
            var val = "F";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Convertor_When_Single_Digit_With_Leading_Zero()
        {
            // Arrange
            var val = "07";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Convertor_When_Single_Letter_With_Leading_Zero()
        {
            // Arrange
            var val = "0B";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Convertor_When_All_Zeros()
        {
            // Arrange
            var val = "0000";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Convertor_When_Double_Digit_Between_10_And_20()
        {
            // Arrange
            var val = "15";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void Convertor_When_Double_Letters_Between_AA_And_FF()
        {
            // Arrange
            var val = "CF";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(207, result);
        }

        [TestMethod]
        public void Convertor_When_Letter_Then_Digit()
        {
            // Arrange
            var val = "B6";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(182, result);
        }

        [TestMethod]
        public void Convertor_When_Digit_Then_Letter()
        {
            // Arrange
            var val = "6B";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(107, result);
        }

        [TestMethod]
        public void Convertor_When_4_Characters()
        {
            // Arrange
            var val = "6BF2";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(27634, result);
        }

        [TestMethod]
        public void Convertor_When_4_Characters_But_Leading_Zero()
        {
            // Arrange
            var val = "0BF2";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(3058, result);
        }

        [TestMethod]
        public void Convertor_When_Many_Digits_And_Letters()
        {
            // Arrange
            var val = "05F2330D";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.AreEqual(99758861, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Convertor_When_Invalid_Letter_Throw_Exception()
        {
            // Arrange
            var val = "G0";

            // Act
            var result = _convertor.ConvertHexadecimalToDecimal(val);

            // Assert
            Assert.Fail("Expected Argument out of range exceoption to have been thrown");
        }

    }
}
