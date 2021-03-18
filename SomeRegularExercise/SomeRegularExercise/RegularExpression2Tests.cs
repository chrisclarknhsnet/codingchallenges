using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression2Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c2_P_FOLLOWED_BY_9_DIGITS);
        }

        [TestMethod]
        public void Allows_When_P_Followed_By_9_Digitas()
        {
            Assert.IsTrue(_expression.IsMatch("P987654324"));
        }

        [TestMethod]
        public void Doesnt_Allow_First_Letter_Other_Than_P()
        {
            Assert.IsFalse(_expression.IsMatch("B987654324"));
        }

        [TestMethod]
        public void Doesnt_Allow_Less_Than_9_Digits()
        {
            Assert.IsFalse(_expression.IsMatch("P98765432"));
        }

        [TestMethod]
        public void Doesnt_Allow_More_Than_9_Digits()
        {
            Assert.IsFalse(_expression.IsMatch("P9876543210"));
        }

        [TestMethod]
        public void Doesnt_Allow_Letters_Other_Than_P_Prefix()
        {
            Assert.IsFalse(_expression.IsMatch("PW87654321"));
        }

        [TestMethod]
        public void Doesnt_Allow_Spaces()
        {
            Assert.IsFalse(_expression.IsMatch("P9876 4321"));
        }

        [TestMethod]
        public void Doesnt_Allow_Punctuation()
        {
            Assert.IsFalse(_expression.IsMatch("P9876,4321"));
        }

        [TestMethod]
        public void Doesnt_Allow_Characters_After_9_Digits()
        {
            Assert.IsFalse(_expression.IsMatch("P987654321,"));
        }
    }
}
