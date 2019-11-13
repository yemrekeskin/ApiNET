using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class PhoneBulkController 
        : ApiControllerBase
    {
        private readonly IPhoneService phoneService;

        public PhoneBulkController(
            IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }
    }
}