namespace ApiNET.Models
{
    /// <summary>
    /// Email data model
    /// </summary>
    public partial class Email
        : BaseModel
    {
        public int CustomerId { get; set; }

        public EmailType EmailType { get; set; }

        public string EmailAddress { get; set; }

        public ActivePassive ActivePassive { get; set; }
        public bool IsDefault { get; set; }
    }
}