using System.Collections.Generic;

namespace Mustang_Sally
{
    public interface ICarDriverQueries
    {
        bool areThereAnySallysWhoDontDriveMustangs(IList<CarDriver> carDrivers);
        int howManySallyMustangs(IList<CarDriver> carDrivers);
    }
}