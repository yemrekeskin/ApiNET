using ApiNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class AddressBulkController
        : ApiControllerBase
    {
        private readonly IAddressService addressService;

        public AddressBulkController(
            IAddressService addressService)
        {
            this.addressService = addressService;
        }
    }
}