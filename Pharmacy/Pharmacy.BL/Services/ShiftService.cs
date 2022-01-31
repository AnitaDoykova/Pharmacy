using System.Collections.Generic;
using System.Linq;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Serilog;

namespace Pharmacy.BL.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftrepository;
        private readonly ILogger _logger;

        public ShiftService(IShiftRepository shiftrepository, ILogger logger)
        {
            _shiftrepository = shiftrepository;
            _logger = logger;
        }
        public Shift Create(Shift shift)
        {
            var index = _shiftrepository.GetAll().OrderByDescending(X => X.Id).FirstOrDefault()?.Id;

            shift.Id = (int)(index != null ? index + 1 : 1);

            return _shiftrepository.Create(shift);
        }

        public Shift Delete(int id)
        {
            return _shiftrepository.Delete(id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftrepository.GetAll();
        }

        public Shift GetById(int id)
        {
            return _shiftrepository.GetById(id);
        }

        public Shift Update(Shift shift)
        {
            return _shiftrepository.Update(shift);
        }
    }
}