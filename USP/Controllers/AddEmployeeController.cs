using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using USP.Models;
using USP.ViewModels;

namespace USP.Controllers
{
    public class AddEmployeeController : Controller
    {
        private EmployeeContext db;

        public AddEmployeeController(EmployeeContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(EmployeeModel employeeModel)
        {
            db.InsertEmployee(employeeModel);
            return RedirectToAction("Index", "EmployeeList");
        }
    }
}