using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIA.Models.DTO;
using SIA.Models.Entity;
using SIA.Models.Repository;

namespace SIA.Controllers
{
    public class HomeController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();
        EncryptDecryptRepository EDrep = new EncryptDecryptRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult dataTransfer(RegistrationFormDTO data)
        {
            RegistrationFormRepository reg = new RegistrationFormRepository();
            bool inserted = reg.insertTodatabase(data);

            return Json(new { success = inserted });

        }

        public string checkUserName(string UserName)
        {

            var checkUserName = db.Registrations.Where(rt => rt.Username == UserName).FirstOrDefault();
            if (checkUserName != null)
            {
                return "false";
            }
            return "true";

        }



    }
}