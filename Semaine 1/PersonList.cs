using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PersonList
    {

        private static PersonList? _instance = null;
        private IDictionary<string, Person> _personMap;

        private PersonList()
        {
            _personMap = new Dictionary<string, Person>();
        }

        public static PersonList getInstance()
        {

            if (_instance == null)
                _instance = new PersonList();

            return _instance;
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentException();
            _personMap.Add(person.Name, person);
        }

        public IEnumerator<Person> personList()
        {
            return _personMap.Values.GetEnumerator();
        }
    }
}
