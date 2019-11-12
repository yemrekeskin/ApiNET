using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Models
{
    public class Customer
        : BaseModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public CustomerRank CustomerRank { get; set; }
    }
}
