using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment.Models
{
    public class PeopleList : IPerson
    {
        public List<Person> personList = new List<Person>();
        public List<Person> personFilter = new List<Person>();

        private int idCount = 1;

        public PeopleList()
        {
            personList.Add(new Person() { Id = 0, Name = "Misaka Mikoto", PhoneNumber = 123456789, City = "Academy City" });
        }

        public List<Person> AllPeople()
        {
            return personList;
        }
        /// <summary>
        /// This method filters the list as per the users wish.
        /// </summary>
        public List<Person> FilterList(string filter)
        {
            personFilter.Clear();

            foreach (Person item in personList)
            {
                if (item.Name.Contains(filter))
                {
                    personFilter.Add(item);
                }
                else if (item.City.Contains(filter))
                {
                    personFilter.Add(item);
                }
            }
            return personFilter;
        }
        /// <summary>
        /// Adds a new person to the list
        /// </summary>
        public Person NewPerson(string name, int phoneNumber, string city)
        {
            Person person = new Person() { Id = idCount, Name = name, PhoneNumber = phoneNumber, City = city };
            idCount++;
            personList.Add(person);
            return person;
        }
        /// <summary>
        /// Removes a person by id
        /// </summary>
        public List<Person> RemovePerson(int id)
        {

            foreach (Person item in personList)
            {
                if (item.Id == id)
                {
                    personList.Remove(item);
                    break;
                }
            }
            return personList;
        }
        /// <summary>
        /// Sorts the list - Not using this method, might implement it later on.
        /// </summary>
        public List<Person> SortList()
        {
            personList.Sort();
            return personList;
        }
    }
}
