using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Controllers
{
    public class CustomerCreate
        : ServiceModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public CustomerRank CustomerRank { get; set; }
    }
}
