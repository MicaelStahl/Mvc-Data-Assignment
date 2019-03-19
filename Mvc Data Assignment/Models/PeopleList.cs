using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Data_Assignment.Models
{
    public class PeopleList : IListModel
    {
        public List<ListModel> listModels = new List<ListModel>();
        public List<ListModel> filteredList = new List<ListModel>();

        private int idCount = 1;

        public PeopleList()
        {
            listModels.Add(new ListModel() { Id = 0, Name = "Test Testsson", PhoneNumber = 123456789, City = "test" });
        }

        public List<ListModel> AllPeople()
        {
            return listModels;
        }
        /// <summary>
        /// I'll work on this one later since I doubt this works.
        /// </summary>
        public List<ListModel> FilterList(string filter)
        {
            foreach (ListModel item in listModels)
            {
                if (item.Name.Contains(filter))
                {
                    filteredList.Add(item);
                }
                else if (item.City.Contains(filter))
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }
        /// <summary>
        /// Adds a new person to the list
        /// </summary>
        public ListModel NewPerson(string name, int phoneNumber, string city)
        {
            ListModel listModel = new ListModel() { Id = idCount, Name = name, PhoneNumber = phoneNumber, City = city };
            idCount++;
            listModels.Add(listModel);
            return listModel;
        }
        /// <summary>
        /// Removes a person by id
        /// </summary>
        public bool RemovePerson(int id)
        {
            bool removedPerson = false;

            foreach (ListModel item in listModels)
            {
                if (item.Id == id)
                {
                    listModels.Remove(item);
                    removedPerson = true;
                    break;
                }
            }
            return removedPerson;
        }
        /// <summary>
        /// Sorts the list
        /// </summary>
        public List<ListModel> SortList()
        {
            listModels.Sort();
            return listModels;
        }
    }
}
