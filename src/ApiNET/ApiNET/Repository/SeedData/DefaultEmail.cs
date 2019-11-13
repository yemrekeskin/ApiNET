using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class DefaultEmail
    {
        public static List<Email> AllEmail()
        {
            return new List<Email>
            {
                Email1,
                Email2
            };
        }
        
        public static readonly Email Email1 = new Email
        {
            Id = 1,
            ActivePassive = ActivePassive.Active,
            EmailType = EmailType.Personal,
            IsDefault = true,
            EmailAddress = "yemrekeskin@gmail.com",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };
                
        public static readonly Email Email2 = new Email
        {
            Id = 2,
            ActivePassive = ActivePassive.Active,
            EmailType = EmailType.Business,
            IsDefault = false,
            EmailAddress = "info@yemrekeskin.com",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };
    }
}
