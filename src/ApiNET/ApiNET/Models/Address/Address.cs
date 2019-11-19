namespace ApiNET.Models
{
    /// <summary>
    /// Address data model
    /// </summary>
    public partial class Address
        : BaseModel
    {
        public int CustomerId { get; set; }

        public AddressType AddressType { get; set; }

        public string FlatNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string BuildingName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string AddressNote { get; set; }

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}