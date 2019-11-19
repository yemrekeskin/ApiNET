using ApiNET.Models;

namespace ApiNET.Controllers
{
    public class CustomerUpdate
        : ServiceModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public CustomerRank CustomerRank { get; set; }
    }
}