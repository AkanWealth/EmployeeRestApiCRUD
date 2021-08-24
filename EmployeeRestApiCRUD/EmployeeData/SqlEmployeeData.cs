
using EmployeeRestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeRestApiCRUD.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if(existingEmployee != null)
            {
                existingEmployee.Fullname = employee.Fullname;
                existingEmployee.Email = employee.Email;
                existingEmployee.Mobile = employee.Mobile;
                existingEmployee.Location = employee.Location;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;

        }

        public Employee GetEmployeeById(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
