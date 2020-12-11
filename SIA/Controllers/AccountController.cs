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
    public class AccountController : Controller
    {
        RegistrationEntities db = new RegistrationEntities();
        EncryptDecryptRepository EDrep = new EncryptDecryptRepository();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dataTransfer(RegistrationFormDTO data)
        {

            Registration reg = new Registration();

            reg.FirstName = data.FirstName;
            reg.MiddleName = data.MiddleName;
            reg.LastName = data.LastName;
            reg.EmailAddress = data.EmailAddress;
            reg.AddressLines = data.AddressLines;
            reg.Username = checkUserName(data.Username);
            reg.Password = EDrep.Encrypt(data.Username, data.Password);
            reg.Contact = data.Contact;
            reg.Birthdate = data.Birthdate;

            //reg.Password = EDrep.Encrypt(data.Username, data.Password); //Fixed

            db.Registrations.Add(reg);
            db.SaveChanges();

            return Json(new { success = true });

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
        public bool loginChecker(loginFormDTO dto)
        {

            var success = false;
            var account = db.Registrations.Where(ad => ad.Username == dto.UserName).FirstOrDefault();

            if (account != null)
            {
                var decryptedPass = EDrep.Decrypt(dto.UserName, account.Password);
                if (decryptedPass == dto.Password)
                {
                    success = true;
                }
            }


            return success;
        }

    }
}