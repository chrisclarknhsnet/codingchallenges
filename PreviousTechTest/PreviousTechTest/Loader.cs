using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PreviousTechTest
{
    public class Loader : ILoader
    {
        private StreamReader _sr;
        private string _currentRow = null;

        public Loader(string filepath)
        {
            
            _sr = new StreamReader(filepath);
        }

        public IList<OrganisationAgeInfo> LoadOrganisationData()
        {
            // If 1st time then just read in 1st line after header row
            if (_currentRow == null)
            {
                _sr.ReadLine();     // Don't need header row
                _currentRow = _sr.ReadLine();
            }

            return getAgeInfoForCurrentRow();
        }

        private IList<OrganisationAgeInfo> getAgeInfoForCurrentRow()
        {
            if (_currentRow == null)
            {
                return null;
            }

            var orgAgeInfo = new List<OrganisationAgeInfo>();
            var ageInfo = _currentRow.GetAgeInfo();
            string startOrgCode = ageInfo.Code;

            do
            {
                orgAgeInfo.Add(ageInfo);
                _currentRow = _sr.ReadLine();

                if (_currentRow != null)
                {
                    ageInfo = _currentRow.GetAgeInfo();
                }

            } while (_currentRow != null && ageInfo.Code == startOrgCode);

            return orgAgeInfo;
        }

        public void GetReader()
        {
            using (StreamReader sr = new StreamReader("test"))
            {
                string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                while ((currentLine = sr.ReadLine()) != null)
                {
                    // Search, case insensitive, if the currentLine contains the searched keyword
                    if (currentLine.IndexOf("I/RPTGEN", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        Console.WriteLine(currentLine);
                    }
                }
            }
        }
    }
}
