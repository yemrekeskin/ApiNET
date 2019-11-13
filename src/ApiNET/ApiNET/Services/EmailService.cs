using ApiNET.Models;
using ApiNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface IEmailService
    {

    }

    public class EmailService
        : IEmailService
    {
        private readonly IRepository<Email> emailRepo;
        private readonly IRepository<EmailMap> emailMapRepo;

        public EmailService(
            IRepository<Email> emailRepo,
            IRepository<EmailMap> emailMapRepo)
        {
            this.emailRepo = emailRepo;
            this.emailMapRepo = emailMapRepo;
        }
    }
}
