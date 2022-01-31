using System.Collections.Generic;
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
