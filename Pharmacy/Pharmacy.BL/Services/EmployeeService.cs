using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Serilog;

namespace Pharmacy.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;
        private readonly ILogger _logger;
        private IEmployeeRepository @object;

        public EmployeeService(IEmployeeRepository @object)
        {
            this.@object = @object;
        }

        public EmployeeService(IEmployeeRepository employeerepository, ILogger logger)
        {
            _employeerepository = employeerepository;
            _logger = logger;
        }
        public Employee Create(Employee employee)
        {
            var index = _employeerepository.GetAll().OrderByDescending(X => X.Id).FirstOrDefault()?.Id;

            employee.Id = (int)(index != null ? index + 1 : 1);

            return _employeerepository.Create(employee);
         }
        
        public Employee Delete(int id)
        {
            return _employeerepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeerepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeerepository.GetById(id);
        }

        public Employee Update(Employee employee)
        {
            return _employeerepository.Update(employee);
        }
    }
}
