namespace ApiNET.Models
{
    /// <summary>
    /// Phone data model
    /// </summary>
    public partial class Phone
        : BaseModel
    {
        public int CustomerId { get; set; }

        public PhoneType PhoneType { get; set; }

        public string Country { get; set; }
        public string AreaCode { get; set; }
        public string Number { get; set; }

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}