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
    }
}
