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
                HttpContext.Session.Remove("_Filter");

                return View(_person.FilterList(filter));
            }
            return View(_person.AllPeople());
        }

        [HttpPost]
        public IActionResult Index(string Name, int? PhoneNumber, string City)
        {
            if (Name != null && PhoneNumber != null && City != null)
            {
                _person.NewPerson(Name, (int)PhoneNumber, City);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                _person.RemovePerson((int)Id);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Filter(string filter)
        {
            if (filter != null)
            {
                HttpContext.Session.SetString("_Filter", filter);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PersonListPartial()
        {
            Person person = new Person();

            return PartialView("_Person", person);
        }
    }
}