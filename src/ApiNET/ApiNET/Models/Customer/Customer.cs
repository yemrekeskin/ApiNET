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