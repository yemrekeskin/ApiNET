using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
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
            return DefaultAddress.AllAddress().ToArray();
        }

        public static Email[] BuildEmail()
        {
            return DefaultEmail.AllEmail().ToArray();
        }

        public static Phone[] BuildPhone()
        {
            return DefaultPhone.AllPhone().ToArray();
        }

        #endregion
    }
}
