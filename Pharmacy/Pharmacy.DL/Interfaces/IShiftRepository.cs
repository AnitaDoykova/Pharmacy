using System.Collections.Generic;
using Pharmacy.Models.DTO;

namespace Pharmacy.DL.Interfaces
{
    public interface IShiftRepository
    {

        Shift Create(Shift shift);

        Shift Update(Shift shift);

        Shift Delete(int id);

        Shift GetById(int id);

        IEnumerable<Shift> GetAll();
    }
}
