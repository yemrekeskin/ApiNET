using ApiNET.Models;
using ApiNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface IAddressService
    {

    }

    public class AddressService
        : IAddressService
    {
        private readonly IRepository<Address> addressRepo;
        private readonly IRepository<AddressMap> addressMapRepo;

        public AddressService(
            IRepository<Address> addressRepo,
            IRepository<AddressMap> addressMapRepo)
        {
            this.addressRepo = addressRepo;
            this.addressMapRepo = addressMapRepo;
        }
    }
}
