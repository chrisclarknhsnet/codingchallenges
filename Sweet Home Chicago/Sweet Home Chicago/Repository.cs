using Sweet_Home_Chicago.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sweet_Home_Chicago
{
    public class Repository : IRepository
    {
        private IList<CrimeSummary> _data = null;
        private string _filename;
        private ILoader _loader;

        public Repository(ILoader loader)
        {
            _loader = loader;
        }

        public string DataFile
        {
            get => _filename;
            set
            {
                if (value != _filename)
                {
                    _filename = value;
                    _data = null;
                }
            }
        }

        private IList<CrimeSummary> CrimeData
        {
            get
            {
                if (_data == null)
                {
                    if (string.IsNullOrWhiteSpace(_filename))
                    {
                        throw new ApplicationException("You must load the data before attempting to use it");
                    }
                    else
                    {
                        _data = _loader.LoadData(_filename);
                    }
                }

                return _data;
            }
        }

        public int GetCount_OfDomesticCrimes()
        {
            return CrimeData.Count(c => c.Domestic);
        }

        public int GetCount_OfStreetHomicides()
        {
            return CrimeData
                .Count(c => c.LocationDescription == "STREET" && c.PrimaryType == "HOMICIDE" );
        }

        public string Get_MostCommonTypeOfCrime()
        {
            return CrimeData
                .GroupBy(g => g.PrimaryType)
                .OrderByDescending(o => o.Count())
                .First()
                .Key;
        }

        public IList<int> Find_SafestDistricts(int noofdistricts)
        {
            return CrimeData
                .Where(c => !c.Domestic)
                .GroupBy(g => g.District)
                .OrderByDescending(o => o.Count())
                .Take(noofdistricts)
                .Select(s => s.Key)
                .ToList();
        }

        public double Get_PercentageOfStreetAssaults_ByWeekday(DayOfWeek weekday)
        {
            return 0;
            //return CrimeData
            //    .Where(c => c.LocationDescription == "STREET" && c.PrimaryType == "ASSAULT")
            //    .GroupBy(g => g.Date.DayOfWeek)
            //    .Select(s => new { DayOfWeek = s.Key, Percentage = s.Count() / s.Sum(sum => sum.Count()))
        }
    }
}
