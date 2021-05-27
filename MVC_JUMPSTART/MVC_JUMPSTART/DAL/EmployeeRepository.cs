using MVC_JUMPSTART.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JUMPSTART.DAL
{
    public class EmployeeRepository
    {
        //Create a method to get the employee list
        public static List<Employee> GetEmployeeList()
        {
            using (MatagujriDataContext dbContext = new MatagujriDataContext())
            {
                List<Employee> dataList = dbContext.Employees.ToList();
                return dataList;
            }
        }


        public static Employee GetEmployeeById(int id)
        {
            using (MatagujriDataContext dbContext = new MatagujriDataContext())
            {
                Employee data = dbContext.Employees.Where(d => d.EmployeeID.Equals(id)).FirstOrDefault();
                return data;
            }
        }

        public static bool CreateEmployee(Employee dbTable)
        {
            using (MatagujriDataContext dbContext = new MatagujriDataContext())
            {
                dbContext.Employees.InsertOnSubmit(dbTable);
                dbContext.SubmitChanges();
                return true;
            }
        }
        public static bool UpdateEmployee(Employee dbTable)
        {
            using (MatagujriDataContext dbContext = new MatagujriDataContext())
            {
                var dbEmployee = dbContext.Employees.Where(d => d.EmployeeID.Equals(dbTable.EmployeeID)).FirstOrDefault();
                dbEmployee.Email = dbTable.Email;
                dbEmployee.Name = dbTable.Name;
                dbEmployee.Mobile = dbTable.Mobile;
                dbContext.SubmitChanges();
                return true;
            }
        }
        public static bool DeleteEmployee(int id)
        {
            using (MatagujriDataContext dbContext = new MatagujriDataContext())
            {
                var dbEmployee = dbContext.Employees.Where(d => d.EmployeeID.Equals(id)).FirstOrDefault();
                dbContext.Employees.DeleteOnSubmit(dbEmployee);
                dbContext.SubmitChanges();
                return true;
            }
        }
    }
}