﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ApiVersion("1.0")]
    public class EmailController 
        : ApiControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(
            IEmailService emailService)
        {
            this.emailService = emailService;
        }
    }
}