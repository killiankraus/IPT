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
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
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