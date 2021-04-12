using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Mustang_Sally;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class MustangSallyCheckerTests
    {
        private const string cFILENAME = @"C:\DUMMY\DUMMY.JSON";

        private IMustangSallyChecker _checker;
        private Mock<IJsonLoader<CarDriver>> _mockJsonLoader;
        private Mock<ICarDriverQueries> _mockCarDriverQueries;

        [TestInitialize]
        public void TestInitialize()
        {
            // Set up mocks and inject into constructor
            _mockJsonLoader = new Mock<IJsonLoader<CarDriver>>();
            _mockCarDriverQueries = new Mock<ICarDriverQueries>();
            
            _checker = new MustangSallyChecker(
                cFILENAME, 
                _mockJsonLoader.Object, 
                _mockCarDriverQueries.Object
            );
        }

        #region Constructor tests

        [TestMethod]
        public void Constructor_Loads_Correct_JSON_File()
        {
            // Arrange
            // Nothing to do Mocks set up in TestInitialze

            // Act
            // Nothing to do constructor called in TestInitialze

            // Assert
            _mockJsonLoader.Verify(m => m.LoadJson(cFILENAME), Times.Once());
        }


        #endregion

        #region Count_Of_Mustang_Sallys Tests

        [TestMethod]
        public void Count_Of_Mustang_Sallys_Returns_Correct_Result()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { id = 101 },
                new CarDriver() { id = 102 }
            };

            _mockJsonLoader.Setup(m => m.LoadJson(It.IsAny<string>()))
                .Returns(carDrivers);

            _mockCarDriverQueries.Setup(m => m.howManySallyMustangs(carDrivers))
                .Returns(11);

            // Act
            // Need to call constructor as part of this test as have altered
            // behaviour of mocks from when called in TestInitialize
            _checker = new MustangSallyChecker(
                cFILENAME,
                _mockJsonLoader.Object,
                _mockCarDriverQueries.Object
            );

            var result = _checker.Count_Of_Mustang_Sallys();

            // Assert
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void Count_Of_Mustang_Sallys_Delegates_Correctly_To_Query_Class()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            { 
                new CarDriver() { id = 101 },
                new CarDriver() { id = 102 }
            };

            _mockJsonLoader.Setup(m => m.LoadJson(It.IsAny<string>()))
                .Returns(carDrivers);

            // Act
            // Need to call constructor as part of this test as have altered
            // behaviour of mocks from when called in TestInitialize
            _checker = new MustangSallyChecker(
                cFILENAME,
                _mockJsonLoader.Object,
                _mockCarDriverQueries.Object
            );

            var result = _checker.Count_Of_Mustang_Sallys();

            // Assert
            // Check that correct list of objects passed to query class
            _mockCarDriverQueries.Verify(
                m => m.howManySallyMustangs(carDrivers),
                Times.Once()
            );
        }

        #endregion

        #region Are_Sallys_Without_Mustang Tests

        [TestMethod]
        public void Are_Sallys_Without_Mustang_When_True_Returns_True()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { id = 101 },
                new CarDriver() { id = 102 }
            };

            _mockJsonLoader.Setup(m => m.LoadJson(It.IsAny<string>()))
                .Returns(carDrivers);

            _mockCarDriverQueries.Setup(m => m.areThereAnySallysWhoDontDriveMustangs(carDrivers))
                .Returns(true);

            // Act
            // Need to call constructor as part of this test as have altered
            // behaviour of mocks from when called in TestInitialize
            _checker = new MustangSallyChecker(
                cFILENAME,
                _mockJsonLoader.Object,
                _mockCarDriverQueries.Object
            );

            var result = _checker.Are_Sallys_Without_Mustang();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Are_Sallys_Without_Mustang_When_False_Returns_False()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { id = 101 },
                new CarDriver() { id = 102 }
            };

            _mockJsonLoader.Setup(m => m.LoadJson(It.IsAny<string>()))
                .Returns(carDrivers);

            _mockCarDriverQueries.Setup(m => m.areThereAnySallysWhoDontDriveMustangs(carDrivers))
                .Returns(false);

            // Act
            // Need to call constructor as part of this test as have altered
            // behaviour of mocks from when called in TestInitialize
            _checker = new MustangSallyChecker(
                cFILENAME,
                _mockJsonLoader.Object,
                _mockCarDriverQueries.Object
            );

            var result = _checker.Are_Sallys_Without_Mustang();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Are_Sallys_Without_Mustang_Delegates_Correctly_To_Query_Class()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { id = 101 },
                new CarDriver() { id = 102 }
            };

            _mockJsonLoader.Setup(m => m.LoadJson(It.IsAny<string>()))
                .Returns(carDrivers);

            // Act
            // Need to call constructor as part of this test as have altered
            // behaviour of mocks from when called in TestInitialize
            _checker = new MustangSallyChecker(
                cFILENAME,
                _mockJsonLoader.Object,
                _mockCarDriverQueries.Object
            );

            var result = _checker.Are_Sallys_Without_Mustang();

            // Assert
            // Check that correct list of objects passed to query class
            _mockCarDriverQueries.Verify(
                m => m.areThereAnySallysWhoDontDriveMustangs(carDrivers),
                Times.Once()
            );
        }

        #endregion
    }
}
