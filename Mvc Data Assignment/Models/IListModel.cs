using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment.Models
{
    public interface IListModel
    {
        // Create
        ListModel NewPerson(string Name, int PhoneNumber, string City);

        // Read All
        List<ListModel> AllPeople();

        // Remove
        bool RemovePerson(int id);

        // Update (sort)
        List<ListModel> SortList();

        // Update (Filter)
        List<ListModel> FilterList(string filter);
    }
}
