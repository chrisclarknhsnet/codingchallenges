using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mustang_Sally;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class CarDriverQueriesTests
    {
        private ICarDriverQueries _querier;

        [TestInitialize]
        public void TestInitialize()
        {
            _querier = new CarDriverQueries();
        }

        #region howManySallyMustangs Tests

        [TestMethod]
        public void howManySallyMustangs_When_Multiple_Returns_Correct_Count()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "Mustang"},
                new CarDriver() { first_name = "Sally", last_name = "Brown", car_model = "Mustang"}
            };

            // Act
            var result = _querier.howManySallyMustangs(carDrivers);

            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void howManySallyMustangs_When_Not_Called_Sally_Does_Not_Include()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Tracey", last_name = "Reynolds", car_model = "Mustang" }
            };

            // Act
            var result = _querier.howManySallyMustangs(carDrivers);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void howManySallyMustangs_When_Not_A_Mustang_Does_Not_Include()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "Mazda MX5" }
            };

            // Act
            var result = _querier.howManySallyMustangs(carDrivers);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void howManySallyMustangs_When_Sally_But_Case_Doesnt_Match_Does_Not_Include()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "sally", last_name = "Reynolds", car_model = "Mustang" }
            };

            // Act
            var result = _querier.howManySallyMustangs(carDrivers);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void howManySallyMustangs_When_Mustang_But_Case_Doesnt_Match_Does_Not_Include()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "MUSTANG" }
            };

            // Act
            var result = _querier.howManySallyMustangs(carDrivers);

            //Assert
            Assert.AreEqual(0, result);
        }

        #endregion

        #region areThereAnySallysWhoDontDriveMustangs Tests

        [TestMethod]
        public void areThereAnySallysWhoDontDriveMustangs_When_One_Returns_True()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "Fiat"}
            };

            // Act
            var result = _querier.areThereAnySallysWhoDontDriveMustangs(carDrivers);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void areThereAnySallysWhoDontDriveMustangs_When_Not_Called_Sally_Returns_False()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Tracey", last_name = "Reynolds", car_model = "Fiat" }
            };

            // Act
            var result = _querier.areThereAnySallysWhoDontDriveMustangs(carDrivers);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void areThereAnySallysWhoDontDriveMustangs_When_Is_A_Mustang_Returns_False()
        { 
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "Mustang" }
            };

            // Act
            var result = _querier.areThereAnySallysWhoDontDriveMustangs(carDrivers);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void areThereAnySallysWhoDontDriveMustangs_When_Sally_But_Case_Doesnt_Match_Returns_False()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "sally", last_name = "Reynolds", car_model = "Fiat" }
            };

            // Act
            var result = _querier.areThereAnySallysWhoDontDriveMustangs(carDrivers);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void areThereAnySallysWhoDontDriveMustangs_When_Mustang_But_Case_Doesnt_Match_Returns_True()
        {
            // Arrange
            var carDrivers = new List<CarDriver>()
            {
                new CarDriver() { first_name = "Sally", last_name = "Reynolds", car_model = "MUSTANG" }
            };

            // Act
            var result = _querier.areThereAnySallysWhoDontDriveMustangs(carDrivers);

            //Assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}
