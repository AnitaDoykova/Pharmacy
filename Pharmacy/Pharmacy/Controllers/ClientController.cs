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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            var result = _clientService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetById")]

        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();

            var result = _clientService.GetById(id);

            if (result == null) return NotFound(id);

            var response = _mapper.Map<ClientResponse>(result);

            return Ok(response);
        }

        [HttpPost("Create")]

        public IActionResult CreateClient([FromBody] ClientRequests clientRequests)
        {
            if (clientRequests == null) return BadRequest();

            var client = _mapper.Map<Client>(clientRequests);

            var result = _clientService.Create(client);

            return Ok(client);

        }

        [HttpDelete]

        public IActionResult Delete (int id)
        {
            if (id <= 0) return BadRequest(id);

            var result = _clientService.Delete(id);

            if (result == null) return NotFound(id);

            return Ok(result);
        }

        [HttpPost("Update")]

        public IActionResult Update([FromBody] ClientUpdateRequests clientRequests)
        {
            if (clientRequests == null) return BadRequest();

            var searchClient = _clientService.GetById(clientRequests.Id);

            if (searchClient == null) return NotFound(clientRequests.Id);

            searchClient.Name = clientRequests.Name;

            var result = _clientService.Update(searchClient);

            return Ok(result);
        }
    }
}
