using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Context
{
    public class SeedData
    {
        #region BuildData

        public static Customer[] BuildCustomer()
        {
            return DefaultCustomer.All().ToArray();
        }

        public static Address[] BuildAddress()
        {
            return DefaultAddress.All().ToArray();
        }

        public static Email[] BuildEmail()
        {
            return DefaultEmail.All().ToArray();
        }

        public static Phone[] BuildPhone()
        {
            return DefaultPhone.All().ToArray();
        }

        #endregion
    }
}
