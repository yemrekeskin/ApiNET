using ApiNET.Models;
using ApiNET.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ApiNET.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }

    public class EmployeeService
        : IEmployeeService
    {
        private readonly IRepository<Employee> employeeRepo;

        public EmployeeService(
            IRepository<Employee> employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        public List<Employee> GetEmployees()
        {
            return employeeRepo.GetList().ToList();
        }
    }
}