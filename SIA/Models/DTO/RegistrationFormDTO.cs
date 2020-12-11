using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIA.Models.DTO
{
    public class RegistrationFormDTO
    {
        public int RegistrationID { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "First Name Should be min 1 and max 20 length")]
        public string FirstName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Middle Name")]
        //[StringLength(20, MinimumLength = 1, ErrorMessage = "Middle Name Should be min 5 and max 20 length")]
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string EmailAddress { get; set; }
        public string AddressLines { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Required")]
        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Contact { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

    }
}