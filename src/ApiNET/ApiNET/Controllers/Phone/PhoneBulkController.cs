using ApiNET.Services;
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