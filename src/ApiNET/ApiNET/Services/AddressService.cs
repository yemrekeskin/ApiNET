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

        public AddressService(
            IRepository<Address> addressRepo)
        {
            this.addressRepo = addressRepo;
        }
    }
}
