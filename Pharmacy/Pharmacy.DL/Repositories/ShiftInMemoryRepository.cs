using System.Collections.Generic;
using System.Linq;
using Pharmacy.Models.DTO;
using Pharmacy.DL.InMemoryDb;
using Pharmacy.DL.Interfaces;

namespace Pharmacy.DL.Repositories
{
    public class ShiftInMemoryRepository : IShiftRepository
    {
        public ShiftInMemoryRepository()
        { }

        public Shift Create(Shift shift)
        {
            ShiftInMemoryCollection.ShiftDb.Add(shift);

            return shift;
        }

        public Shift Delete(int id)
        {
            var shift = ShiftInMemoryCollection.ShiftDb.FirstOrDefault(shift => shift.Id == id);

            ShiftInMemoryCollection.ShiftDb.Remove(shift);

            return shift;
        }

        public IEnumerable<Shift> GetAll()
        {
            return ShiftInMemoryCollection.ShiftDb;
        }

        public Shift GetById(int id)
        {
            return ShiftInMemoryCollection.ShiftDb.FirstOrDefault(x => x.Id == id);
        }

        public Shift Update(Shift shift)
        {
            var result = ShiftInMemoryCollection.ShiftDb.FirstOrDefault(x => x.Id == shift.Id);

            result.Name = shift.Name;

            return result;
        }
    }
}