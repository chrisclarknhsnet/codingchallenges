using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression5Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c5_START_BEGIN_END_TAGS);
        }

        [TestMethod]
        public void Allows_When_Starts_With_Start_Tag()
        {
            Assert.IsTrue(_expression.IsMatch("START:Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_Start_Tag_Is_Lower_Case()
        {
            Assert.IsFalse(_expression.IsMatch("start:Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_Start_Tag_Is_Missing_Colon()
        {
            Assert.IsFalse(_expression.IsMatch("STARTHere is some text:END"));
        }

        [TestMethod]
        public void Allows_When_Starts_With_Begin_Tag()
        {
            Assert.IsTrue(_expression.IsMatch("BEGIN:Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_Begin_Tag_Is_Lower_Case()
        {
            Assert.IsFalse(_expression.IsMatch("begin:Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_Begin_Tag_Is_Missing_Colon()
        {
            Assert.IsFalse(_expression.IsMatch("BEGIN Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_Starts_With_Neither_Valid_Tag()
        {
            Assert.IsFalse(_expression.IsMatch("GO:Here is some text:END"));
        }

        [TestMethod]
        public void Allows_When_End_With_End_Tag()
        {
            Assert.IsTrue(_expression.IsMatch("START:Here is some text:END"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_End_Tag_Is_Lower_Case()
        {
            Assert.IsFalse(_expression.IsMatch("START:Here is some text:end"));
        }

        [TestMethod]
        public void Doesnt_Allow_When_No_End_Tag()
        {
            Assert.IsFalse(_expression.IsMatch("START:Here is some text"));
        }

        [TestMethod]
        public void Allows_Any_Characters_Between_Tags()
        {
            Assert.IsTrue(_expression.IsMatch("START:Here START:is :END some text:END"));
        }
    }
}
