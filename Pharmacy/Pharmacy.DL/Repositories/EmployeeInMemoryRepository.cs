using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;
using Pharmacy.DL.InMemoryDb;
using Pharmacy.DL.Interfaces;

namespace Pharmacy.DL.Repositories
{
    public class EmployeeInMemoryRepository : IEmployeeRepository
    {
        public EmployeeInMemoryRepository()
        { }

        public Employee Create(Employee employee)
        {
            EmployeeInMemoryCollection.EmployeeDb.Add(employee);

            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(employee => employee.Id == id);

            EmployeeInMemoryCollection.EmployeeDb.Remove(employee);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeeInMemoryCollection.EmployeeDb;
        }

        public Employee GetById(int id)
        {
            return EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee employee)
        {
            var result = EmployeeInMemoryCollection.EmployeeDb.FirstOrDefault(x => x.Id == employee.Id);

            result.Name = employee.Name;

            return result;
        }
    }
}