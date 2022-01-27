using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Models.Requests
{
    public class EmployeeUpdateRequests
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }
    }
}
