using ApiNET.Models;
using ApiNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
    }

    public class CustomerService
        : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly IAddressService addressService;
        private readonly IPhoneService phoneService;
        private readonly IEmailService emailService;


        public CustomerService(
            IRepository<Customer> _customerRepository,
            IAddressService addressService,
            IPhoneService phoneService,
            IEmailService emailService)
        {
            this._customerRepository = _customerRepository;
            this.addressService = addressService;
            this.phoneService = phoneService;
            this.emailService = emailService;
        }

        public List<Customer> GetCustomers()
        {
            var result = _customerRepository.GetList();
            return result.ToList();
        }
    }
}
