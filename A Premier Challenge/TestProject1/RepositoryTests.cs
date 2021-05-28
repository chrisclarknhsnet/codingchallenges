using A_Premier_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository _respository;
        private IList<TeamResults> _data;

        [TestInitialize]
        public void TestInitialize()
        {
            _data = new List<TeamResults>();
            _respository = new Repository(_data);
        }

        [TestMethod]
        public void GetCount_Returns_Correct_Count()
        {
            // Arrange
            _data.Add(new TeamResults());
            _data.Add(new TeamResults());

            // Act
            var result = _respository.GetCount();

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetCount_When_Empty_Returns_Zero()
        {
            // Arrange

            // Act
            var result = _respository.GetCount();

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCount_When_Null_Throws_Exception()
        {
            // Arrange
            _respository = new Repository(null);

            // Act
            var result = _respository.GetCount();

            // Assert
            Assert.Fail("Expected a null reference exception to be thrown");
        }
    }
}
