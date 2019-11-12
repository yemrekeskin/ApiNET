using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Context
{
    public class DefaultPhone
    {
        public static List<Phone> All()
        {
            return new List<Phone>
            {
                Phone1,
                Phone2
            };
        }
        
        public static readonly Phone Phone1 = new Phone
        {
           
        };

        public static readonly Phone Phone2 = new Phone
        {

        };
    }
}
