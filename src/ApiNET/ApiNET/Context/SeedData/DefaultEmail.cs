using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Context
{
    public class DefaultEmail
    {
        public static List<Email> All()
        {
            return new List<Email>
            {
                Email1,
                Email2
            };
        }

        public static readonly Email Email1 = new Email
        {

        };

        public static readonly Email Email2 = new Email
        {

        };
    }
}
