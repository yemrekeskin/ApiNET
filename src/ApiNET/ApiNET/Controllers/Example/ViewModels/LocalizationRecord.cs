namespace ApiNET.Controllers
{
    internal class LocalizationRecord
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
        public string LocalizationCulture { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
    }
}