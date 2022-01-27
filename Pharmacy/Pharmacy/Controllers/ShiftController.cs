using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pharmacy.BL.Interfaces;
using Pharmacy.Models.DTO;
using Pharmacy.Models.Requests;
using Pharmacy.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly IMapper _mapper;

        public ShiftController(IShiftService shiftService, IMapper mapper)
        {
            _shiftService = shiftService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _shiftService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _shiftService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<ShiftResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreateShift([FromBody] ShiftRequests shiftRequests)
        {
            if (shiftRequests == null) return BadRequest();

            var shift = _mapper.Map<Shift>(shiftRequests);

            var result = _shiftService.Create(shift);

            return Ok(shift);

        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _shiftService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] ShiftUpdateRequests shiftRequests)
        {
            if (shiftRequests == null) return BadRequest();

            var searchShift = _shiftService.GetById(shiftRequests.Id);

            if (searchShift == null) return NotFound(shiftRequests.Id);

            searchShift.Name = shiftRequests.Name;

            var result = _shiftService.Update(searchShift);

            return Ok(result);
        }
    }
}
