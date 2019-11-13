using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class DefaultPhone
    {
        public static List<Phone> AllPhone()
        {
            return new List<Phone>
            {
                Phone1,
                Phone2
            };
        }

        public static readonly Phone Phone1 = new Phone
        {
            Id = 1,
            ActivePassive = ActivePassive.Active,
            IsDefault = true,
            PhoneType = PhoneType.Home,

            Country = "90",
            AreaCode = "212",
            Number = "3786869",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };

        public static readonly Phone Phone2 = new Phone
        {
            Id = 2,
            ActivePassive = ActivePassive.Active,
            IsDefault = false,
            PhoneType = PhoneType.Mobile,

            Country = "90",
            AreaCode = "543",
            Number = "5556677",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };


        public static List<PhoneMap> AllPhoneMap()
        {
            return new List<PhoneMap>
            {
                PhoneMap1,
                PhoneMap2
            };
        }

        public static readonly PhoneMap PhoneMap1 = new PhoneMap
        {
            Id = 1,
            PhoneId = 1,
            CustomerId = 1,

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };

        public static readonly PhoneMap PhoneMap2 = new PhoneMap
        {
            Id = 2,
            PhoneId = 1,
            CustomerId = 1,

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };
    }
}
