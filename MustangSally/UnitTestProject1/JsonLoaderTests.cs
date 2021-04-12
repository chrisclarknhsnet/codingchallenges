using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mustang_Sally;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class JsonLoaderTests
    {
        private IJsonLoader<CarDriver> _loader;

        [TestInitialize]
        public void TestInitialize()
        {
            _loader = new JsonLoader<CarDriver>();
        }

        #region LoadJson tests

        // Use fake JSON data to test

        [TestMethod]
        [DeploymentItem("Resources/JSON/CarDrivers_Good.json")]
        public void LoadJson_When_JSON_Exists_And_Valid_Returns_Objects()
        {
            // Arrange
            var filename = "./CarDrivers_Good.json";  // NOTE file is set to copy to output directory

            // Act
            var result = _loader.LoadJson(filename);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Any(cd => cd.last_name == "Moniker"));
            Assert.IsTrue(result.Any(cd => cd.last_name == "Playfair"));
        }

        [TestMethod]
        [DeploymentItem("Resources/JSON/CarDrivers_Bad.json")]
        [ExpectedException(typeof(JsonSerializationException))]
        public void LoadJson_When_JSON_Exists_But_Invalid_Returns_Objects()
        {
            // Arrange
            var filename = "./CarDrivers_Bad.json";  // NOTE file is set to copy to output directory

            // Act
            var result = _loader.LoadJson(filename);

            // Assert
            Assert.Fail("Expected exception to be thrown on deserialization");
        }

        #endregion
    }
}
