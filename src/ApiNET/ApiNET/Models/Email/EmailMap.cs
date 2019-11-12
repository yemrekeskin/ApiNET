using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNET.Models
{
    /// <summary>
    /// PhoneMap data model
    /// </summary>
    public class EmailMap 
        : BaseModel
    {
        public long EmailId { get; set; }
        public string UserId { get; set; }
    }
}
