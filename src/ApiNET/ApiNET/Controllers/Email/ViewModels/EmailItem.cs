using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Controllers
{
    public class EmailItem
    {
        public int CustomerId { get; set; }

        public EmailType EmailType { get; set; }

        public string EmailAddress { get; set; }

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}
