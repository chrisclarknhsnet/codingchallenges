using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tell_Me_About_Yourself;
using Tell_Me_About_Yourself.POCOs;

namespace UnitTestProject1
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private IPersonRepository _repository;
        private IList<Person> _people;

        [TestInitialize]
        public void TestInitialize()
        {
            _people = new List<Person>();
            _repository = new PersonRepository(_people);
        }

        #region FindSurnames_ByFirstName Tests

        [TestMethod]
        public void FindSurnames_ByFirstName_When_Multiple_Matches_Returns_All()
        {
            // Arrange
            var firstname = "Irene";
            _people.Add(new Person() { first_name = firstname, last_name = "Smith" });
            _people.Add(new Person() { first_name = firstname, last_name = "Jones" });
            
            // Act
            var result = _repository.FindSurnames_ByFirstName(firstname);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(ln => ln == "Smith"));
            Assert.IsTrue(result.Any(ln => ln == "Jones"));
        }

        [TestMethod]
        public void FindSurnames_ByFirstName_When_No_Matches_Returns_Empty()
        {
            // Arrange
            var firstname = "Irene";
            _people.Add(new Person() { first_name = firstname, last_name = "Smith" });

            // Act
            var result = _repository.FindSurnames_ByFirstName("iReNe");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void FindSurnames_ByFirstName_When_Match_But_Case_Different_Does_Not_Return_Result()
        {
            // Arrange
            var firstname = "Irene";

            // Act
            var result = _repository.FindSurnames_ByFirstName(firstname);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region Get_Max_No_Of_Contacts_For_Any_Person tests

        [TestMethod]
        public void Get_Max_No_Of_Contacts_For_Any_Person_Returns_Correct_Result()
        {
            // Arrange
            _people.Add(new Person() { contacts = new List<string>() { "Contact1", "Contact2" } });
            _people.Add(new Person() { contacts = new List<string>() { "Contact4", "Contact5", "Conteact6" } });
            _people.Add(new Person() { contacts = new List<string>() { "Contact3" } });

            // Act
            var result = _repository.Get_Max_No_Of_Contacts_For_Any_Person();

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Get_Max_No_Of_Contacts_WHen_No_Contacts_Returns_Zero()
        {
            // Arrange
            _people.Add(new Person() { contacts = null });

            // Act
            var result = _repository.Get_Max_No_Of_Contacts_For_Any_Person();

            // Assert
            Assert.AreEqual(0, result);
        }

        #endregion
    }
}
