using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Controllers
{
    public class PagedList<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
    }
}
