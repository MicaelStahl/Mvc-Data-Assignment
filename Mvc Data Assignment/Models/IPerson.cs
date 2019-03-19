using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment.Models
{
    public interface IPerson
    {
        // Create
        Person NewPerson(string Name, int PhoneNumber, string City);

        // Read All
        List<Person> AllPeople();

        // Remove
        List<Person> RemovePerson(int id);

        // Update (sort)
        List<Person> SortList();

        // Update (Filter)
        List<Person> FilterList(string filter);
    }
}
