using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;

namespace Pharmacy.Models.Responses
{
    public class ShiftResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
