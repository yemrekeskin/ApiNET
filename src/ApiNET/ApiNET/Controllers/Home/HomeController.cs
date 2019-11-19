using ApiNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    public class HomeController
        : Controller
    {
        private readonly ICustomerService customerService;

        public HomeController(
            ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = customerService.GetCustomers();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}