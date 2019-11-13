using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class DefaultAddress
    {
        public static List<Address> AllAddress()
        {
            return new List<Address>
            {
                Address1,
                Address2
            };
        }

        public static readonly Address Address1 = new Address
        {
            Id = 1,
            ActivePassive = ActivePassive.Active,
            IsDefault = true,
            AddressType = AddressType.Home,

            Country = "Turkey",
            County = "Istanbul",
            Town = "Pendik",
            Street = "Yenisehir",

            BuildingName = "MaviBalina Apt.",
            BuildingNumber = "123",
            FlatNumber = "52",

            PostCode = "34300",
            AddressNote = "Dont post any letter",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now            
        };

        public static readonly Address Address2 = new Address
        {
            Id = 2,
            ActivePassive = ActivePassive.Passive,
            IsDefault = false,
            AddressType = AddressType.Work,

            Country = "Turkey",
            County = "Istanbul",
            Town = "Pendik",
            Street = "Yenisehir",

            BuildingName = "Teknopark Istanbul",
            BuildingNumber = "321",
            FlatNumber = "3",

            PostCode = "34600",
            AddressNote = "",

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };
    }
}
