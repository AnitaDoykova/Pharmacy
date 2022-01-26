using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.InMemoryDb
{
    public static class ShiftInMemoryCollection
    {
        public static List<Shift> ShiftDb = new List<Shift>()
        {
            new Shift()
            {
                Id = 1,
                Name = "Day Shift",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "Anna",
                        Salary = 500
                    },
                  new Employee()
                    {
                        Id = 2,
                        Name = "Nikola",
                       Salary = 520
                   }
                }
            },
            new Shift()
            {
                Id=2,
                Name = "Night Shift",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "Georgi",
                        Salary = 550
                    },
                    new Employee()
                    {
                        Id = 2,
                        Name = "Ivana",
                        Salary = 520
                    }
                }
            }
        };
    }
}
