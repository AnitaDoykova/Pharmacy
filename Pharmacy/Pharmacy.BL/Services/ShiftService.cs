﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.DL.Interfaces;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;

namespace Pharmacy.BL.Services
{
    public class ShiftService
    {
        private readonly IShiftRepository _shiftrepository;

        public ShiftService(IShiftRepository shiftrepository)
        {
            _shiftrepository = shiftrepository;
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