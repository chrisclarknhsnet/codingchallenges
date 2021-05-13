using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tell_Me_About_Yourself.POCOs;

namespace Tell_Me_About_Yourself
{
    public class PersonRepository : IPersonRepository
    {
        IList<Person> _people;

        public PersonRepository(IList<Person> people)
        {
            _people = people;
        }

        public virtual IEnumerable<string> FindSurnames_ByFirstName(string firstName)
        {
            return _people
                .Where(p => p.first_name == firstName)
                .Select(s => s.last_name);
        }

        public int Get_Max_No_Of_Contacts_For_Any_Person()
        {
            return _people.Max(p => p.contacts?.Count) ?? 0;
        }

        public bool People_Have_At_Least_X_Contacts(int minnoofcontacts)
        {
            return _people.Any(p => p.contacts?.Count >= minnoofcontacts);
        }
    }
}
