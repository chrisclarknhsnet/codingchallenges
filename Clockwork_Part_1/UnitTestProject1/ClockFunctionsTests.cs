using Clockwork_Drivers_Part1;
using Clockwork_Part_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ClockFunctionsTests
    {
        private Mock<ILedClockDriver> _mockDriver;
        private ClockFunctions _clockFunctions;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDriver = new Mock<ILedClockDriver>();
            _clockFunctions = new ClockFunctions(_mockDriver.Object);
        }

        #region Test methods

        [TestMethod]
        public void showTime_Shows_Correct_Minutes()
        {
            // Arrange
            var timeToShow = new DateTime(2020, 11, 11, 1, 37, 0);
            
            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), true), Times.Once());
            _mockDriver.Verify(m => m.showLed(37, true), Times.Once());
        }

        [TestMethod]
        public void showTime_When_Exactly_On_The_Hour_Shows_Hour_As_Whole_Number()
        {
            // Arrange
            var timeToShow = new DateTime(2020, 11, 11, 1, 0, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Once());
            _mockDriver.Verify(m => m.showLed(5, false), Times.Once());
        }

        [TestMethod]
        public void showTime_When_Exactly_Minutes_Exact_Multiple_Of_12_Shows_Correct_Hour_Tick()
        {
            // Arrange
            // 36 mins = 3 ticks past the hour
            var timeToShow = new DateTime(2020, 11, 11, 1, 36, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Once());
            _mockDriver.Verify(m => m.showLed(8, false), Times.Once());
        }

        [TestMethod]
        public void showTime_When_Minutes_Not_Exact_Multiple_Of_12_Shows_Rounded_Down_Hour_Tick()
        {
            // Arrange
            // 30 mins = between tick 2 and 3 past the hour, so expect 2
            var timeToShow = new DateTime(2020, 11, 11, 1, 30, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Once());
            _mockDriver.Verify(m => m.showLed(7, false), Times.Once());
        }

        [TestMethod]
        public void showTime_Shows_When_12_OClock_Shows_Single_Bright_Led()
        {
            // Arrange
            var timeToShow = new DateTime(2020, 11, 11, 12, 0, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert#
            _mockDriver.Verify(m => m.showLed(0, true), Times.Once());
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Never());
        }

        [TestMethod]
        public void showTime_When_23_59_Shows_Correct_Minutes_And_Hours()
        {
            // Arrange
            var timeToShow = new DateTime(2020, 11, 11, 23, 59, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(59, true), Times.Once());
            // Both should be on led 59 so no hour display
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Never());
        }

        [TestMethod]
        public void showTime_When_Midnight_Shows_Correct_Minutes_And_Hours()
        {
            // Arrange
            var timeToShow = new DateTime(2020, 11, 11, 0, 0, 0);

            // Act
            _clockFunctions.showTime(timeToShow);

            // Assert
            _mockDriver.Verify(m => m.showLed(0, true), Times.Once());
            _mockDriver.Verify(m => m.showLed(It.IsAny<int>(), false), Times.Never());
        }

        #endregion
    }
}
