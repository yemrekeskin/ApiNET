using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNET.Models
{
    /// <summary>
    /// PhoneMap data model
    /// </summary>
    public class PhoneMap 
        : BaseModel
    {
        public long PhoneId { get; set; }
        public string UserId { get; set; }
    }
}
