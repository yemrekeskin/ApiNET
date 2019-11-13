using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public class ApiResponse<T>
    { 
        public bool Success { get; set; }
        public T Result { get; set; } = default(T);
    }
}
