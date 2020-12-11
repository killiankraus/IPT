using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using SIA.Models.DTO;
using SIA.Models.Entity;
using SIA.Models.Checking;



namespace SIA.Models.Repository
{
    public class RegistrationFormRepository
    {
        RegistrationEntities db = new RegistrationEntities();
        EncryptDecryptRepository EDrep = new EncryptDecryptRepository();
        Check check = new Check();

        public bool insertTodatabase(RegistrationFormDTO registrationFormDTO)
        {

            Registration reg = new Registration();
            
            //registrationFormDTO.RegistrationID
        

            //reg.FirstName = registrationFormDTO.FirstName;
            //reg.MiddleName = registrationFormDTO.MiddleName;
            //reg.LastName = registrationFormDTO.LastName;
            //reg.EmailAddress = registrationFormDTO.EmailAddress;
            //reg.AddressLines = registrationFormDTO.AddressLines;
            //reg.Username = registrationFormDTO.Username;
            //reg.Password = registrationFormDTO.Password;
            //reg.Contact = registrationFormDTO.Contact;
            //reg.Birthdate = registrationFormDTO.Birthdate;


            //db.Registrations.Add(reg);
            //db.SaveChanges();

            reg.FirstName = registrationFormDTO.FirstName;
            reg.MiddleName = registrationFormDTO.MiddleName;
            reg.LastName = registrationFormDTO.LastName;
            reg.EmailAddress = registrationFormDTO.EmailAddress;
            reg.AddressLines = registrationFormDTO.AddressLines;
            reg.Username = registrationFormDTO.Username;
            reg.Password = EDrep.Encrypt(registrationFormDTO.Username, registrationFormDTO.Password);
            reg.Contact = registrationFormDTO.Contact;
            reg.Birthdate = registrationFormDTO.Birthdate;


            db.Registrations.Add(reg);
            try
            {
                db.SaveChanges();
                
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            return true;
        }
    }
}