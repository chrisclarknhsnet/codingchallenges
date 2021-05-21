using HitMeDataOneMoreTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class RepositoryTests
    {
        private IRepository _repository;
        private IList<HitSingle> _data;

        [TestInitialize]
        public void TestInitialize()
        {
            _data = new List<HitSingle>();
            _repository = new Repository(_data);
        }

        #region Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000 tests
        
        [TestMethod]
        public void Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000_Returns_Correct_Count()
        {
            // Arrange
            var artist = "XTC";
            _data.Add(new HitSingle() { artist = artist, dateentered = new DateTime(2000, 4, 1) });
            _data.Add(new HitSingle() { artist = artist, dateentered = new DateTime(2000, 1, 1) });

            // Act
            var result = _repository.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(artist);

            // Assert
            Assert.AreEqual(2, result);
        }

        #endregion

        [TestMethod]
        public void Get_No_Of_Hit_Singles_By_Artist_When_Not_For_Artist_Doesnt_Include_In_Count()
        {
            // Arrange
            var artist = "XTC";
            _data.Add(new HitSingle() { artist = artist + "x", dateentered = new DateTime(2000, 4, 1) });

            // Act
            var result = _repository.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(artist);

            // Assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void Get_No_Of_Hit_Singles_By_Artist_When_Charted_Prior_To_2000_Doesnt_Include_In_Count()
        {
            // Arrange
            var artist = "XTC";
            _data.Add(new HitSingle() { artist = artist, dateentered = new DateTime(1999, 12, 31) });

            // Act
            var result = _repository.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(artist);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Get_No_Of_Hit_Singles_By_Artist_When_Data_Empty_Returns_Zero()
        {
            // Arrange
            var artist = "XTC";

            // Act
            var result = _repository.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(artist);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_No_Of_Hit_Singles_By_Artist_When_Data_Null_Throws_Exception()
        {
            // Arrange
            var artist = "XTC";
            _repository = new Repository(null);

            // Act
            var result = _repository.Get_No_Of_Hit_Singles_By_Artist_Within_Year_2000(artist);

            // Assert
            Assert.Fail("Expected exception to be thrown due to null data");
        }
    }
}
