using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNET.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ApiNET.Controllers
{
    [ODataRoutePrefix("Employee")]
    public class EmployeeController 
        : ODataController
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(
            IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [ODataRoute]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get()
        {
            var result = employeeService.GetEmployees();
            return Ok(result);
        }

        [ODataRoute("({key})")]
        [EnableQuery(PageSize = 20, AllowedQueryOptions = AllowedQueryOptions.All)]
        public IActionResult Get([FromODataUri] int key)
        {
            var result = employeeService.GetEmployees().Where(d => d.Id == key);
            return Ok(result);
        }

    }
}