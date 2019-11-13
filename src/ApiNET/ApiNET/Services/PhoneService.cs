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

        public PhoneService(
            IRepository<Phone> phoneRepo)
        {
            this.phoneRepo = phoneRepo;
        }
    }
}
