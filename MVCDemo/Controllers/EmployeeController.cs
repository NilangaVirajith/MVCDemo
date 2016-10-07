using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLayer;
using System;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.employees.ToList();
            return View(employees);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            TryUpdateModel(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            Employee employee = employeeBusinessLayer.employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int EmployeeId)
        {
            Employee employee = employeeBusinessLayer.employees.Single(emp => emp.EmployeeId == EmployeeId);
            UpdateModel<IEmployee>(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                employeeBusinessLayer.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}