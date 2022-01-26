using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.InMemoryDb
{
    public static class EmployeeInMemoryCollection
    {
        public static List<Employee> EmployeeDb = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Anna",
                Salary = 500
            },
            new Employee()
            {
                Id= 2,
                Name = "Georgi",
                Salary = 550
            },
            new Employee()
            {
                Id = 3,
                Name = "Nikola",
                Salary = 520
            },
            new Employee()
            {
                Id = 4,
                Name = "Ivana",
                Salary = 520
            }
        };
    }
}
