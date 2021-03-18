using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression3Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c3_VALID_HEXADECIMAL);
        }

        [TestMethod]
        public void Allows_When_Valid_Hexadecimal()
        {
            Assert.IsTrue(_expression.IsMatch("F90A"));
            Assert.IsTrue(_expression.IsMatch("9F0A"));
        }

        [TestMethod]
        public void Doesnt_Allow_Lower_Case_Letters()
        {
            Assert.IsFalse(_expression.IsMatch("F90a"));
        }

        [TestMethod]
        public void Doesnt_Allow_Odd_Number_Of_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("AF3"));
        }
        
        [TestMethod]
        public void Doesnt_Allow_Letters_After_F()
        {
            Assert.IsFalse(_expression.IsMatch("F90G"));
        }

        [TestMethod]
        public void Doesnt_Allow_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("F9 0A"));
        }

        [TestMethod]
        public void Doesnt_Allow_Punctuation()
        {
            Assert.IsFalse(_expression.IsMatch("F9.0A"));
        }

        [TestMethod]
        public void Doesnt_Allow_Leading_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch(" F90A"));
        }

        [TestMethod]
        public void Doesnt_Allow_Trailing_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("F90A "));
        }
    }
}
