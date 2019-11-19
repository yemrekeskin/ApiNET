using ApiNET.Models;
using ApiNET.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Services
{
    public interface IPhoneService
    {
        Phone AddPhone(Phone phone);

        bool UpdatePhone(Phone phone);

        bool DeletePhone(long id);

        List<Phone> GetPhone();

        List<Phone> GetPhoneByCustomerId(long customerId);

        Phone GetPhoneById(long id);
    }

    public class PhoneService
        : IPhoneService
    {
        private readonly IRepository<Phone> phoneRepo;

        public PhoneService(
            IRepository<Phone> phoneRepo)
        {
            this.phoneRepo = phoneRepo;
        }

        public Phone AddPhone(Phone phone)
        {
            phoneRepo.Add(phone);
            return phone;
        }

        public bool DeletePhone(long id)
        {
            phoneRepo.Remove(id);
            return true;
        }

        public List<Phone> GetPhone()
        {
            return phoneRepo.GetList().ToList();
        }

        public List<Phone> GetPhoneByCustomerId(long customerId)
        {
            return phoneRepo.FindAll(d => d.CustomerId == customerId).ToList();
        }

        public Phone GetPhoneById(long id)
        {
            return phoneRepo.FindById(id);
        }

        public bool UpdatePhone(Phone phone)
        {
            phoneRepo.Update(phone);
            return true;
        }
    }
}