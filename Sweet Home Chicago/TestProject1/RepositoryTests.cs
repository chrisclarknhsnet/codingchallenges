using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sweet_Home_Chicago;
using Sweet_Home_Chicago.POCO;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository _repository;
        private Mock<ILoader> _mockLoader;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLoader = new Mock<ILoader>();
            _repository = new Repository(_mockLoader.Object);
        }

        [TestMethod]
        public void GetCount_OfDomesticCrimes_Returns_Correct_Value()
        {
            // Arrange
            var filename = "dummy.csv";
            
            var data = new List<CrimeSummary>()
            {
                new CrimeSummary() { Domestic = true  },
                new CrimeSummary() { Domestic = false },
                new CrimeSummary() { Domestic = true }
            };

            _mockLoader.Setup(m => m.LoadData(filename)).Returns(data);

            // Act
            _repository.DataFile = filename;
            var result = _repository.GetCount_OfDomesticCrimes();

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}
