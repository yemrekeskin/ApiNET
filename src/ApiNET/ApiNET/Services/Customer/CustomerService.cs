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

        public CustomerService(IRepository<Customer> _customerRepository)
        {
            this._customerRepository = _customerRepository;
        }

        public List<Customer> GetCustomers()
        {
            var result = _customerRepository.GetList();
            return result.ToList();
        }
    }
}
