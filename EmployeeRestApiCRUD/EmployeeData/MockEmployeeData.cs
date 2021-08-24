using EmployeeRestApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestApiCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Fullname = "Employee one",
                Email = "employee1@gmail.com",
                Mobile = "+1237070707070",
                Location = "Lagos"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Fullname = "Employee two",
                Email = "employee2@gmail.com",
                Mobile = "+1237071717171",
                Location = "Abuja"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.Id);
            existingEmployee.Fullname = employee.Fullname;
            existingEmployee.Email = employee.Email;
            existingEmployee.Mobile = employee.Mobile;
            existingEmployee.Location = employee.Location;
            return existingEmployee;
        }

        public Employee GetEmployeeById(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
