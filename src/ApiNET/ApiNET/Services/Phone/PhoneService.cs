using ApiNET.Models;
using ApiNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface IPhoneService
    {

    }

    public class PhoneService
        : IPhoneService
    {
        private readonly IRepository<Phone> phoneRepo;
        private readonly IRepository<PhoneMap> phoneMapRepo;

        public PhoneService(
            IRepository<Phone> phoneRepo,
            IRepository<PhoneMap> phoneMapRepo)
        {
            this.phoneRepo = phoneRepo;
            this.phoneMapRepo = phoneMapRepo;
        }
    }
}
