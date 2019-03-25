using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USP.Models;

namespace USP.Controllers
{
    public class EmployeeListController : Controller
    {
        [Authorize]
        public IActionResult Index(EmployeeContext employeeContext)
        {
            List<Employee> employees = employeeContext.GetAllEmployees();
            return PartialView(employees);
        }
    }
}