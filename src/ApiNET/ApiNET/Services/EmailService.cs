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
        Email AddEmail(Email email);

        bool UpdateEmail(Email email);
        bool DeleteEmail(long id); 

        List<Email> GetEmail(); 
        List<Email> GetEmailByCustomerId(long customerId);
        Email GetEmailById(long id);

    }

    public class EmailService
        : IEmailService
    {
        private readonly IRepository<Email> emailRepo;

        public EmailService(
            IRepository<Email> emailRepo)
        {
            this.emailRepo = emailRepo;
        }

        public Email AddEmail(Email email)
        {
            emailRepo.Add(email);
            return email;
        }

        public bool DeleteEmail(long id)
        {
            emailRepo.Remove(id);
            return true;
        }

        public List<Email> GetEmail()
        {
            return emailRepo.GetList().ToList();
        }

        public List<Email> GetEmailByCustomerId(long customerId)
        {
            return emailRepo.FindAll(d => d.CustomerId == customerId).ToList();
        }

        public Email GetEmailById(long id)
        {
            return emailRepo.FindById(id);
        }

        public bool UpdateEmail(Email email)
        {
            emailRepo.Update(email);
            return true;
        }
    }
}
