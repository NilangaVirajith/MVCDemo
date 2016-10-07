using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class DepartmentController : Controller
    {
        EmployeeContext employeeContext = new EmployeeContext();

        public ActionResult Index()
        {
            List<Department> depts = employeeContext.Departments.ToList();
            return View(depts);
        }
    }
}
