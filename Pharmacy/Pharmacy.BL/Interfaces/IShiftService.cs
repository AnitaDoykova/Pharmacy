using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Models.DTO;


namespace Pharmacy.BL.Interfaces
{
    public interface IShiftService
    {
        Shift Create(Shift shift);

        Shift Update(Shift shift);

        Shift Delete(int id);

        Shift GetById(int id);

        IEnumerable<Shift> GetAll();
    }
}
