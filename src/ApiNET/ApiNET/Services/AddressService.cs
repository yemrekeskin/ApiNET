using ApiNET.Models;
using ApiNET.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Services
{
    public interface IAddressService
    {
        Address AddAddress(Address address);

        bool UpdateAddress(Address address);

        bool DeleteAddress(long id);

        List<Address> GetAddress();

        List<Address> GetAddressByCustomerId(long customerId);

        Address GetAddressById(long id);
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

        public Address AddAddress(Address address)
        {
            addressRepo.Add(address);
            return address;
        }

        public bool DeleteAddress(long id)
        {
            addressRepo.Remove(id);
            return true;
        }

        public List<Address> GetAddress()
        {
            return addressRepo.GetList().ToList();
        }

        public List<Address> GetAddressByCustomerId(long customerId)
        {
            return addressRepo.FindAll(d => d.CustomerId == customerId).ToList();
        }

        public Address GetAddressById(long id)
        {
            return addressRepo.FindById(id);
        }

        public bool UpdateAddress(Address address)
        {
            addressRepo.Update(address);
            return true;
        }
    }
}