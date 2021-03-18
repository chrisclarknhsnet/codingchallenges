using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression4Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c4_VALID_GUID);
        }

        [TestMethod]
        public void Allows_When_Valid_GUID_Starting_With_Letter()
        {
            Assert.IsTrue(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Allows_When_Valid_GUID_Starting_With_Digit()
        {
            Assert.IsTrue(_expression.IsMatch("2A345678-1B23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Lower_Case_Letters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1b23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Letters_After_F()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1A23-12F4-A0C4-F9EGD7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Seperators_Other_Than_Dash()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678~1b23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_First_Group_More_Than_8_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A234567810~1b23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_First_Group_Less_Than_8_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A234567~1b23-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Second_Group_More_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B235-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Second_Group_Less_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B3-12F4-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Third_Group_More_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F45-A0C4-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Third_Group_Less_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F-A0C4-F9E8D7C6B5A4"));
        }
        [TestMethod]
        public void Doesnt_Allow_Fourth_Group_More_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C45-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Fourth_Group_Less_Than_4_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C-F9E8D7C6B5A4"));
        }

        [TestMethod]
        public void Doesnt_Allow_Fifth_Group_More_Than_12_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8D7C6B5A41"));
        }

        [TestMethod]
        public void Doesnt_Allow_Second_Group_Less_Than_12_Characters()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8D7C6B5A"));
        }

        [TestMethod]
        public void Doesnt_Allow_Punctuation_Other_Than_Seperators()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8-7C6B5AC"));
        }

        [TestMethod]
        public void Doesnt_Allow_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8D C6B5AC"));
        }

        [TestMethod]
        public void Doesnt_Allow_Leading_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch(" A2345678-1B23-12F4-A0C4-F9E8D7C6B5AC"));
        }

        [TestMethod]
        public void Doesnt_Allow_Trailing_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("A2345678-1B23-12F4-A0C4-F9E8D7C6B5AC "));
        }
    }
}
