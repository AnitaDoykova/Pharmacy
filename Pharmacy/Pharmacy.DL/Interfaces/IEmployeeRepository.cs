using System.Collections.Generic;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);

        Employee Update(Employee employee);

        Employee Delete(int id);

        Employee GetById(int id);

        IEnumerable<Employee> GetAll();
    }
}
