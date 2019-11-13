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
    public class PhoneController 
        : ApiControllerBase
    {
        private readonly IPhoneService phoneService;

        public PhoneController(
            IPhoneService phoneService)
        {
            this.phoneService = phoneService;
        }
    }
}