using ApiNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class EmailBulkController
        : ApiControllerBase
    {
        private readonly IEmailService emailService;

        public EmailBulkController(
            IEmailService emailService)
        {
            this.emailService = emailService;
        }
    }
}