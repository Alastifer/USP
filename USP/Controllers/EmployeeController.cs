﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USP.Models;

namespace USP.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        public IActionResult Index(int Id, EmployeeContext employeeContext)
        {
            Employee employee = employeeContext.GetEmployee(Id);
            return PartialView(employee);
        }
    }
}