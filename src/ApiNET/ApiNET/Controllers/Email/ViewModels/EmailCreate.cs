using ApiNET.Models;

namespace ApiNET.Controllers
{
    public class EmailCreate
        : ServiceModel
    {
        public int CustomerId { get; set; }

        public EmailType EmailType { get; set; }

        public string EmailAddress { get; set; }

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}