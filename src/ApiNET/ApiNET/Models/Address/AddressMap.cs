using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNET.Models
{
    /// <summary>
    /// Mapper model for address data
    /// </summary>
    public class AddressMap 
        : BaseModel
    {
        public long AddressId { get; set; }
        public long CustomerId { get; set; }  
    }
}
