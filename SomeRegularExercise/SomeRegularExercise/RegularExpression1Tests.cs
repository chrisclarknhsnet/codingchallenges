using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression1Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c1_ALPHANUMERIC_ONLY);
        }

        [TestMethod]
        public void Allows_Alpha()
        {
            Assert.IsTrue(_expression.IsMatch("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }

        [TestMethod]
        public void Allows_Numeric()
        {
            Assert.IsTrue(_expression.IsMatch("0123456789"));
        }

        [TestMethod]
        public void Doesnt_Allow_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("ABC DEF"));
        }

        [TestMethod]
        public void Doesnt_Allow_Punctuation()
        {
            Assert.IsFalse(_expression.IsMatch("ABC,DEF"));
        }

        [TestMethod]
        public void Doesnt_Allow_Empty()
        {
            Assert.IsFalse(_expression.IsMatch(""));
        }
    }
}
