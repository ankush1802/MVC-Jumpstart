using MVC_JUMPSTART.DAL;
using MVC_JUMPSTART.Database;
using MVC_JUMPSTART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JUMPSTART.BAL
{
    public class EmployeeManager
    {
        public static List<EmployeeViewModel> GetEmployeeList()
        {
            List<EmployeeViewModel> response = new List<EmployeeViewModel>();
            List<Employee> dataList = EmployeeRepository.GetEmployeeList();
            foreach(Employee employee in dataList)
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                emp.Id = employee.EmployeeID;
                emp.Email = employee.Email;
                emp.Name = employee.Name;
                response.Add(emp);
            }
            return response;
        }


        public static EmployeeViewModel GetEmployeeById(int id)
        {
            Employee data = EmployeeRepository.GetEmployeeById(id);
            EmployeeViewModel response = new EmployeeViewModel();
            response.Email = data.Email;
            response.Id = data.EmployeeID;
            response.Mobile = data.Mobile;
            response.Name = data.Name;
            return response;
        }

        public static bool CreateEmployee(EmployeeViewModel model)
        {
            Employee dbTable = new Employee();
            dbTable.Email = model.Email;
            dbTable.Mobile = model.Mobile;
            dbTable.Name = model.Name;
            return EmployeeRepository.CreateEmployee(dbTable);
        }
        public static bool UpdateEmployee(EmployeeViewModel model)
        {
            Employee dbTable = new Employee();
            dbTable.EmployeeID = model.Id;
            dbTable.Email = model.Email;
            dbTable.Mobile = model.Mobile;
            dbTable.Name = model.Name;
            return EmployeeRepository.UpdateEmployee(dbTable);
        }

        public static bool DeleteEmployee(int id)
        {
            return EmployeeRepository.DeleteEmployee(id);
        }
    }
}