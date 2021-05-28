using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A_Premier_Challenge
{
    public class Repository : IRepository
    {
        private IList<TeamResults> _results;

        public Repository(IList<TeamResults> results)
        {
            _results = results;
        }

        public int GetCount()
        {
            return _results.Count();
        }
    }
}
