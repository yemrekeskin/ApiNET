using Newtonsoft.Json;
using System;

namespace ApiNET.Controllers
{
    public class FilterModel
    {
        // search like - start with
        public String Term { get; set; }

        public int Page { get; set; }
        public int Limit { get; set; }

        public FilterModel()
        {
            this.Page = 1;
            this.Limit = 3;
        }

        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}