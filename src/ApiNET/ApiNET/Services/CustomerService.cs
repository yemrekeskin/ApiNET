using ApiNET.Models;
using ApiNET.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomers(IEnumerable<long> ids);

        Customer GetCustomer(long id);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(long id);

        Customer AddCustomer(Customer customer);
    }

    public class CustomerService
        : ICustomerService
    {
        private readonly IRepository<Customer> customerRepo;

        private readonly IAddressService addressService;
        private readonly IPhoneService phoneService;
        private readonly IEmailService emailService;

        public CustomerService(
            IRepository<Customer> customerRepo,
            IAddressService addressService,
            IPhoneService phoneService,
            IEmailService emailService)
        {
            this.customerRepo = customerRepo;
            this.addressService = addressService;
            this.phoneService = phoneService;
            this.emailService = emailService;
        }

        public Customer AddCustomer(Customer customer)
        {
            customerRepo.Add(customer);
            return customer;
        }

        public bool DeleteCustomer(long id)
        {
            customerRepo.Remove(id);
            return true;
        }

        public Customer GetCustomer(long id)
        {
            return customerRepo.FindById(id);
        }

        public List<Customer> GetCustomers()
        {
            var result = customerRepo.GetList();
            return result.ToList();
        }

        public List<Customer> GetCustomers(IEnumerable<long> ids)
        {
            return customerRepo.FindAll(d => ids.Contains(d.Id)).ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            customerRepo.Update(customer);
            return true;
        }
    }
}