using ADO_NetTest.EntityFramework.Model.TSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetTest.EntityFramework.Service
{
    class EmployeeService
    {
        public void AddEmployee(Employee employee)
        {
            using (var db = new BloggingContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public void AddEmplyeeList()
        {
            var rd = new Random();

            for (int i = 1; i <= 100; i++)
            {
                int marId = 0;
                if (i > 10)
                {
                    marId = rd.Next(1, 10);
                }

                var employee = new Employee
                {
                    EmployeeId = i,
                    FirstName = "Employee" + i,
                    LastName = "Employee" + i,
                    MarId = marId,
                    HireDate = DateTime.Now.AddDays(rd.Next(-100, 100)),
                    Salary = rd.Next(3000, 10000),
                    Ssn = "201902020000" + i,
                };

                AddEmployee(employee);
            }            
        }

    }
}
