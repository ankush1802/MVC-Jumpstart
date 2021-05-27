using MVC_JUMPSTART.BAL;
using MVC_JUMPSTART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_JUMPSTART.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetEmployeeList()
        {
            List<EmployeeViewModel> objViewModel = EmployeeManager.GetEmployeeList();
            return View(objViewModel);
        }

        //GET:ID Employee/{id}
        public ActionResult GetEmployeeById(int id)
        {
            EmployeeViewModel objViewModel = EmployeeManager.GetEmployeeById(id);
            if(objViewModel == null)
            {
                objViewModel = new EmployeeViewModel();
            }
            return View(objViewModel);
        }

        //POST || INSERT || CREATE
        public ActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeViewModel postEmployeeViewModel)
        {
            if(ModelState.IsValid)
            {
                bool result = EmployeeManager.CreateEmployee(postEmployeeViewModel);
                if (result)
                {
                    return RedirectToAction("GetEmployeeList");
                }
            }
           
            return View();
        }

        //PUT || UPDATE
        public ActionResult UpdateEmployee(int id)
        {
            EmployeeViewModel objViewModel = EmployeeManager.GetEmployeeById(id);
            if (objViewModel == null)
            {
                objViewModel = new EmployeeViewModel();
            }
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeViewModel objViewModel)
        {
            if (ModelState.IsValid)
            {
                bool result = EmployeeManager.UpdateEmployee(objViewModel);
                if (result)
                {
                    return RedirectToAction("GetEmployeeList");
                }
            }

            return View();
        }

        //DELETE
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeViewModel objViewModel = EmployeeManager.GetEmployeeById(id);
            if (objViewModel == null)
            {
                objViewModel = new EmployeeViewModel();
            }
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeViewModel objViewModel)
        {
            bool result = EmployeeManager.DeleteEmployee(objViewModel.Id);
            if (result)
            {
                return RedirectToAction("GetEmployeeList");
            }
            return View();
        }
    }
}