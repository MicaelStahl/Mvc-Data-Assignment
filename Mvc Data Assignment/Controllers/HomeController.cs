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

        IListModel _listModel;

        public HomeController(IListModel listModel)
        {
            _listModel = listModel;
        }

        public IActionResult Index()
        {
            string filter = HttpContext.Session.GetString("_Filter");

            if (filter != null)
            {
                ViewBag.Filter = filter;
                return View(_listModel.FilterList(filter));
            }
            return View(_listModel.AllPeople());
        }
        [HttpPost]
        public IActionResult Index(string Name, int PhoneNumber, string City, string filter)
        {
            if (filter != null)
            {
                HttpContext.Session.SetString("_Filter", filter);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                HttpContext.Session.SetString("_Name", Name);
                HttpContext.Session.SetInt32("_PhoneNumber", PhoneNumber);
                HttpContext.Session.SetString("_City", City);

                string name = HttpContext.Session.GetString("_Name");
                int phoneNumber = (int)HttpContext.Session.GetInt32("_PhoneNumber");
                string city = HttpContext.Session.GetString("_City");

                _listModel.NewPerson(name, phoneNumber, city);
            }

            return View(_listModel.AllPeople());
        }
    }
}