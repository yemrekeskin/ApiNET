using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiNET.Models
{
    /// <summary>
    /// Email data model
    /// </summary>
    public partial class Email 
        : BaseModel
    {
        public EmailType EmailType { get; set; }

        public string EmailAddress { get; set; }        

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}
