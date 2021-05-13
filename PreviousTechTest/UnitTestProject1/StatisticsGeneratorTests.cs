using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreviousTechTest;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class StatisticsGeneratorTests
    {
        IStatisticsGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new StatisticsGenerator();
        }

        [TestMethod]
        public void GenerateStatistics_Returns_All_Male_Patients_Count()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>()
            {
                new OrganisationAgeInfo() 
                { 
                    IsTotal = true,
                    NoMalePatients = 32,
                    NoFemalePatients = 65
                }
            };

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.AreEqual(32, result.TotalMalePatients);
        }

        [TestMethod]
        public void GenerateStatistics_When_No_Male_Patients_Returns_0()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>()
            {
                new OrganisationAgeInfo()
                {
                    IsTotal = true,
                    NoMalePatients = 0,
                    NoFemalePatients = 65
                }
            };

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.AreEqual(0, result.TotalMalePatients);
        }

        [TestMethod]
        public void GenerateStatistics_Returns_All_Female_Patients_Count()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>()
            {
                new OrganisationAgeInfo()
                {
                    IsTotal = true,
                    NoMalePatients = 32,
                    NoFemalePatients = 65
                }
            };

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.AreEqual(65, result.TotalFemalePatients);
        }

        [TestMethod]
        public void GenerateStatistics_When_No_Female_Patients_Returns_0()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>()
            {
                new OrganisationAgeInfo()
                {
                    IsTotal = true,
                    NoMalePatients = 32,
                    NoFemalePatients = 0
                }
            };

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.AreEqual(0, result.TotalFemalePatients);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GenerateStatistics_When_No_Totals_Row_Throws_Exception()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>();

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.Fail("Expected exception as no total values");
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GenerateStatistics_When_Multiple_Totals_Row_Throws_Exception()
        {
            // Arrange
            var ageRows = new List<OrganisationAgeInfo>()
            {
                new OrganisationAgeInfo()
                {
                    IsTotal = true,
                    NoMalePatients = 32,
                    NoFemalePatients = 0
                },
                new OrganisationAgeInfo()
                {
                    IsTotal = true,
                    NoMalePatients = 1,
                    NoFemalePatients = 1
                }
            };

            // Act
            var result = _generator.GenerateStatistics(ageRows);

            // Assert
            Assert.Fail("Expected exception as multiple total values");
        }
    }
}
