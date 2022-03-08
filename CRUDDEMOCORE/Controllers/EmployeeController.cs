using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDDEMOCORE.Models;

namespace CRUDDEMOCORE.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDAL = new EmployeeDAL();
        public IActionResult Index()
        {
            List<Employee> Emplist = new List<Employee>();
            Emplist = employeeDAL.GetAllEmployee().ToList();
            return View(Emplist);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create([Bind]Employee emp)
        {
            if (ModelState.IsValid)
            {
                employeeDAL.Cretae(emp);
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        }
    }
}
