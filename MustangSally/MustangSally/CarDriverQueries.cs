using System.Collections.Generic;
using System.Linq;

namespace Mustang_Sally
{
    public class CarDriverQueries : ICarDriverQueries
    {
        // How many people named Sally drive a Mustang car?
        public int howManySallyMustangs(IList<CarDriver> carDrivers)
        {
            return carDrivers.Count(
                cd =>
                cd.first_name == "Sally" &&
                cd.car_model == "Mustang");
        }

        public bool areThereAnySallysWhoDontDriveMustangs(IList<CarDriver> carDrivers)
        {
            return carDrivers.Any(
                cd =>
                cd.first_name == "Sally" &&
                cd.car_model != "Mustang");
        }
    }
}
