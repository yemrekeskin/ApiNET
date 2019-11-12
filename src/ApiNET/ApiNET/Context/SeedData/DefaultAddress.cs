using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Context
{
    public class DefaultAddress
    {
        public static List<Address> All()
        {
            return new List<Address>
            {
                Address1,
                Address2
            };
        }

        public static readonly Address Address1 = new Address
        {

        };

        public static readonly Address Address2 = new Address
        {

        };
    }
}
