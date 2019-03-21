using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Data_Assignment.Models;

namespace Mvc_Data_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionKeyName = "_Name";
        public const string SessionKeyPhoneNumber = "_PhoneNumber";
        public const string SessionKeyCity = "_City";
        public const string SessionKeyFilter = "_Filter";

        IPerson _person;

        public HomeController(IPerson person)
        {
            _person = person;
        }
        [HttpGet]
        public IActionResult Index()
        {
            string filter = HttpContext.Session.GetString("_Filter");

            if (filter != null)
            {
                return View(_person.FilterList(filter));
            }
            return View(_person.AllPeople());
        }
        [HttpPost]
        public IActionResult Index(string Name, int? PhoneNumber, string City, string filter, int? Id)
        {
            if (filter != null)
            {
                HttpContext.Session.SetString("_Filter", filter);

                return RedirectToAction("Index", "Home");
            }
            else if (Id != null)
            {
                return View(_person.RemovePerson((int)Id));
            }
            if (Name == null || PhoneNumber == null || City == null)
            {
                return View();
            }
            if (Name != null && PhoneNumber != null && City != null)
            {
                HttpContext.Session.SetString("_Name", Name);
                HttpContext.Session.SetInt32("_PhoneNumber", (int)PhoneNumber);
                HttpContext.Session.SetString("_City", City);

                string name = HttpContext.Session.GetString("_Name");
                int phoneNumber = (int)HttpContext.Session.GetInt32("_PhoneNumber");
                string city = HttpContext.Session.GetString("_City");

                _person.NewPerson(name, phoneNumber, city);
                return View(_person.AllPeople());
            }

            return View();
        }
        public IActionResult PersonListPartial ()
        {
            

            return PartialView(_person);
        }
    }
}