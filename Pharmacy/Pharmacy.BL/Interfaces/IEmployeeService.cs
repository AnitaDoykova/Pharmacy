using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;


namespace Pharmacy.BL.Interfaces
{
    public interface IEmployeeService
    {
        Employee Create(Employee employee);

        Employee Update(Employee employee);

        Employee Delete(int id);

        Employee GetById(int id);

        IEnumerable<Employee> GetAll();
    }
}
