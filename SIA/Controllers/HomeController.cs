using SIA.Models.DTO;
using SIA.Models.Repository;
using System.Web.Mvc;


namespace SIA.Controllers
{
    public class HomeController : Controller
    {

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
            //Registration reg = new Registration();

            //reg.FirstName = data.FirstName;
            //reg.MiddleName = data.MiddleName;
            //reg.LastName = data.LastName;
            //reg.EmailAddress = data.EmailAddress;
            //reg.AddressLines = data.AddressLines;
            //reg.Username = checkUserName(data.Username);
            //reg.Password = EDrep.Encrypt(data.Username, data.Password);
            //reg.Contact = data.Contact;
            //reg.Birthdate = data.Birthdate;


            //db.Registrations.Add(reg);
            //db.SaveChanges();

            bool inserted = reg.insertTodatabase(data);

            return Json(new { success = inserted });

        }





    }
}