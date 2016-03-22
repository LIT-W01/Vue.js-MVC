using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VueJs.Data;

namespace VueJsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPeople()
        {
            return Json(new PersonRepo().GetPeople(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            new PersonRepo().AddPerson(person);
            return Json(person);
        }

        [HttpPost]
        public void DeletePerson(int id)
        {
            new PersonRepo().Delete(id);
        }

        [HttpPost]
        public void UpdatePerson(Person person)
        {
            new PersonRepo().Update(person);
        }
    }
}
