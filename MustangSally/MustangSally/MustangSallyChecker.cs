using System.Collections.Generic;

namespace Mustang_Sally
{
    public class MustangSallyChecker : IMustangSallyChecker
    {
        private ICarDriverQueries _queries;
        private IList<CarDriver> _carDrivers;

        /// <summary>
        /// Constructor to inject dependencies as interfaces
        /// </summary>
        /// <param name="filename">The JSON filename and path</param>
        /// <param name="loader">An instance of the JSON Loader interface</param>
        /// <param name="queries">An instance of the LINQ querier interface</param>
        public MustangSallyChecker(string filename, IJsonLoader<CarDriver> loader, ICarDriverQueries queries)
        {
            // Load and deserialize the JSON
            _carDrivers = loader.LoadJson(filename);
            _queries = queries;
        }

        public int Count_Of_Mustang_Sallys()
        {
            return _queries.howManySallyMustangs(_carDrivers);
        }

        public bool Are_Sallys_Without_Mustang()
        {
            return _queries.areThereAnySallysWhoDontDriveMustangs(_carDrivers);
        }
    }
}
