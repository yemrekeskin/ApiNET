using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Models
{
    public class Employee
        : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
    }
}
