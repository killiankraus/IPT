using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using SIA.Models.Entity;
using SIA.Models.Repository;

namespace SIA.Models.Checking
{
    public class Check
    {
        RegistrationEntities db = new RegistrationEntities();
       
        public string checkUserName(string StudentId)
        {
            var checkStudentId = db.Registrations.Where(s => s.Username == StudentId).FirstOrDefault();
            if (checkStudentId != null)
            {
                return "false";
            }
            return "true";
        }


        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}