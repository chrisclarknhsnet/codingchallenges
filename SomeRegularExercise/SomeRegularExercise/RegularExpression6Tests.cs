using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace SomeRegularExercise
{
    [TestClass]
    public class RegularExpression6Tests
    {
        private Regex _expression;

        [TestInitialize]
        public void Initialize()
        {
            _expression = new Regex(Expressions.c6_CAPTURING_GROUP);
        }

        [TestMethod]
        public void When_Valid_Returns_Payload()
        {
            var match = _expression.Match("START:Here is some text:END");
            var payload = match.Groups["Payload"].Value;
            Assert.AreEqual("Here is some text", payload);
        }
    }
}
